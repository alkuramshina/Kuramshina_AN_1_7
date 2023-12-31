using Player;
using UnityEngine;

namespace Map
{
    public class DangerZone : MonoBehaviour
    {
        private static PlayerHealth _playerHealth;
        private void Awake()
        {
            _playerHealth = FindObjectOfType<PlayerHealth>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _playerHealth.Decrease();
        }
    }
}
