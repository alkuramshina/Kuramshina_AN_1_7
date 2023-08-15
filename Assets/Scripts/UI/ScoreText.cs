using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreText : MonoBehaviour
    {
        private PlayerScore _playerScore;
        private TMP_Text _scoreText;
    
        private void Awake()
        {
            _scoreText = GetComponent<TMP_Text>();
        
            _playerScore = FindObjectOfType<PlayerScore>();
            _playerScore.ScoreChanged += UpdateCurrentScore;
        }

        private void Start()
        {
            UpdateCurrentScore();
        }

        private void UpdateCurrentScore()
        {
            _scoreText.text = $"Score: {_playerScore.Score}";
        }
    }
}
