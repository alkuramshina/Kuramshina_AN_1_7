using UnityEngine;

namespace Player
{
    public class OldInput : PlayerMovement
    {
        protected override void Update()
        {
            CheckForJump();
            CheckForMoveLeft();
            CheckForMoveRight();
        
            base.Update();
        }

        private void CheckForJump()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
                Jump();
        }

        private void CheckForMoveLeft()
        {
            if (Input.GetKey(KeyCode.A))
                MoveLeft();
        }
    
        private void CheckForMoveRight()
        {
            if (Input.GetKey(KeyCode.D))
                MoveRight();
        }
    }
}
