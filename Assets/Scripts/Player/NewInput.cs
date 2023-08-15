using UnityEngine.InputSystem;

namespace Player
{
    public class NewInput : PlayerMovement
    {
        private PlayerControls _playerControls;

        protected override void Awake()
        {
            _playerControls = new PlayerControls();
            base.Awake();
        }
        
        private void OnEnable()
        {
            _playerControls.Enable();

            _playerControls.Default.Jump.performed += Jump;
            _playerControls.Default.Left.performed += Left;
            _playerControls.Default.Right.performed += Right;
        }

        private void Jump(InputAction.CallbackContext context) => Jump();
        private void Left(InputAction.CallbackContext context) => MoveLeft();
        private void Right(InputAction.CallbackContext context) => MoveRight();

        private void OnDisable()
        {
            _playerControls.Disable();
        }
    }
}
