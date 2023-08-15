using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] [FormerlySerializedAs("Max Health")]
        private int maxHealth = 20;

        public int Health { get; private set; }
        
        public bool IsDead => Health <= 0;
        public Action HealthChanged;

        private void Awake()
        {
            Health = maxHealth;
        }

        public void Decrease()
        {
            Health--;
            HealthChanged?.Invoke();
        }
    }
}
