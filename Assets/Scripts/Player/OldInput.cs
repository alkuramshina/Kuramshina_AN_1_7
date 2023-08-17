using UnityEngine;

namespace Player
{
    public class OldInput : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        
        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }
        
        private void Update()
        {
            CheckForJump();
            CheckForMoveLeft();
            CheckForMoveRight();
        }

        private void CheckForJump()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
                _playerMovement.Jump();
        }

        private void CheckForMoveLeft()
        {
            if (Input.GetKey(KeyCode.A))
                _playerMovement.MoveLeft();
        }
    
        private void CheckForMoveRight()
        {
            if (Input.GetKey(KeyCode.D))
                _playerMovement.MoveRight();
        }
    }
}
