using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class PlayerMovement : MonoBehaviour
    {
        [SerializeField][FormerlySerializedAs("Speed")] private float speed;
        [SerializeField][FormerlySerializedAs("Horizontal Speed")] private float xSpeed;
        [SerializeField][FormerlySerializedAs("Jump Height")] private float jumpHeight;

        private Rigidbody _rigidbody;

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected virtual void Update()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            var initialVelocity = _rigidbody.velocity;
            Move(new Vector3(initialVelocity.x, initialVelocity.y, speed));
        }

        protected void Jump()
        {
            _rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        protected void MoveLeft()
        {
            var initialVelocity = _rigidbody.velocity;
            Move(new Vector3(-xSpeed, initialVelocity.y, initialVelocity.z));
        }
    
        protected void MoveRight()
        {
            var initialVelocity = _rigidbody.velocity;
            Move(new Vector3(xSpeed, initialVelocity.y, initialVelocity.z));
        }

        private void Move(Vector3 direction) => _rigidbody.velocity = direction;
    }
}
