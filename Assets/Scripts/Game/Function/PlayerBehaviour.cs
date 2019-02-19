using Model;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// �����Ϊ��
    /// </summary>
    public class PlayerBehaviour : IPlayerBehaviour
    {
        private readonly Transform _playerTrans;
        private readonly PlayerDataModel _model;
        private bool _isAttack;
        private Vector3 _faceDirection;
        private bool _isFaceDirectionChange;

        public PlayerBehaviour(Transform player, PlayerDataModel model)
        {
            _playerTrans = player;
            _model = model;
            _isAttack = false;
            _faceDirection = Vector3.zero;
            _isFaceDirectionChange = false;
        }

        public void Idle()
        {
            _isAttack = false;
        }

        public void TurnForward()
        {
            if (_isAttack)
                return;
            _faceDirection = Vector3.zero;
            _isFaceDirectionChange = true;
        }

        public void TurnBack()
        {
            if(_isAttack)
                return;
            _faceDirection = Vector3.up * 180;
            _isFaceDirectionChange = true;
        }

        public void TurnLeft()
        {
            if (_isAttack)
                return;
            _faceDirection = Vector3.up * -90;
            _isFaceDirectionChange = true;
        }

        public void TurnRight()
        {

            if (_isAttack)
                return;
            _faceDirection = Vector3.up * 90;
            _isFaceDirectionChange = true;
        }

        public void Move()
        {
            if (_isFaceDirectionChange)
            {
                _isFaceDirectionChange = false;
                PlayerOrientation(_faceDirection);
            }
            _playerTrans.Translate(Time.deltaTime * _model.Speed * Vector3.forward, Space.Self);
        }

        public bool IsRun { get; set; }

        public void Attack(int skillCode)
        {
            _isAttack = true;
        }

        private void PlayerOrientation(Vector3 direction)
        {
            _playerTrans.eulerAngles = direction;
        }
    }
}
