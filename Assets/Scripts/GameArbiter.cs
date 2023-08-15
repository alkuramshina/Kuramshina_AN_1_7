using Player;
using UnityEditor;
using UnityEngine;

public class GameArbiter : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private CountDown _countDown;

    private void Awake()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _countDown = FindObjectOfType<CountDown>();
    }

    private void Update()
    {
        if (_playerHealth.IsDead || transform.position.y < 0 || _countDown.TimeIsUp)
        {
            GameOver();
        }
    }

    private static void GameOver()
    {
        EditorApplication.isPaused = true;
        Debug.Log("Game is over!");
    }
}
