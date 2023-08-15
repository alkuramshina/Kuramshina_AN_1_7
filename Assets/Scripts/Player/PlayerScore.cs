using System;
using UnityEngine;

namespace Player
{
    public class PlayerScore : MonoBehaviour
    {
        public int Score { get; private set; }
        public Action ScoreChanged;

        private void Awake()
        {
            Score = 0;
        }

        public void Increase()
        {
            Score++;
            ScoreChanged?.Invoke();
        }
    }
}
