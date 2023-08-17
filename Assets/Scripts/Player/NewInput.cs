using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class NewInput : MonoBehaviour
    {
        private PlayerControls _playerControls;
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerControls = new PlayerControls();
            _playerMovement = GetComponent<PlayerMovement>();
        }
        
        private void OnEnable()
        {
            _playerControls.Enable();

            _playerControls.Default.Jump.performed += Jump;
            
            _playerControls.Default.Left.performed += Left;
            _playerControls.Default.Left.canceled += StopXMovement;
            
            _playerControls.Default.Right.performed += Right;
            _playerControls.Default.Right.canceled += StopXMovement;
        }

        private void Jump(InputAction.CallbackContext context) => _playerMovement.Jump();
        private void Left(InputAction.CallbackContext context) => _playerMovement.MoveLeft();
        private void Right(InputAction.CallbackContext context) => _playerMovement.MoveRight();
        private void StopXMovement(InputAction.CallbackContext context) => _playerMovement.StopXMovement();

        private void OnDisable()
        {
            _playerControls.Disable();
        }
    }
}
