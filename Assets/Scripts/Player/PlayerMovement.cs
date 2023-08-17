using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField][FormerlySerializedAs("Starting Speed")] private float startingSpeed;
        [SerializeField][FormerlySerializedAs("Max Speed")] private float maxSpeed;
        [SerializeField][FormerlySerializedAs("Min Speed")] private float minSpeed;
        [SerializeField][FormerlySerializedAs("Horizontal Speed")] private float xSpeed;
        [SerializeField][FormerlySerializedAs("Jump Height")] private float jumpHeight;
        [SerializeField][FormerlySerializedAs("Acceleration Rate")] private float accelerationRate;
        [SerializeField][FormerlySerializedAs("Slow Down Rate")] private float slowDownRate;

        private Rigidbody _rigidbody;
        private float Speed { get; set; }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            Speed = startingSpeed;
        }

        private void Update()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            Debug.Log(Speed);
            
            var initialVelocity = _rigidbody.velocity;
            _rigidbody.velocity = new Vector3(initialVelocity.x, initialVelocity.y, Speed);
        }

        internal void Jump()
        {
            _rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        internal void MoveLeft()
        {
            var initialVelocity = _rigidbody.velocity;
            _rigidbody.velocity = new Vector3(-xSpeed, initialVelocity.y, initialVelocity.z);
        }
    
        internal void MoveRight()
        {
            var initialVelocity = _rigidbody.velocity;
            _rigidbody.velocity = new Vector3(xSpeed, initialVelocity.y, initialVelocity.z);
        }
        
        internal void StopXMovement()
        {
            var initialVelocity = _rigidbody.velocity;
            _rigidbody.velocity = new Vector3(0, initialVelocity.y, initialVelocity.z);
        }

        internal void Accelerate()
        {
            var newSpeed = Speed * accelerationRate;
            if (newSpeed <= maxSpeed)
            {
                Speed = newSpeed;
                Debug.Log($"Speed is increased: {Speed}");
            }
            else
            {
                Debug.Log($"Speed is maxed: {Speed}");
            }
        }

        internal void SlowDown()
        {
            var newSpeed = Speed * slowDownRate;
            if (newSpeed >= minSpeed)
            {
                Speed = newSpeed;
                Debug.Log($"Speed is decreased: {Speed}");
            }
            else
            {
                Debug.Log($"Speed is minimum: {Speed}");
            }
        }
    }
}
