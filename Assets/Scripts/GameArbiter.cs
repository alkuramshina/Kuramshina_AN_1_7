using Player;
using UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class GameArbiter : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private CountDown _countDown;
    private PlayerMovement _playerMovement;
    
    [SerializeField][FormerlySerializedAs("Acceleration Delta Time")] 
    private float accelerationDeltaTime = 10.0f;
    private float _accelerationTimer = 0f;

    private void Awake()
    {
        _countDown = FindObjectOfType<CountDown>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerHealth = GetComponent<PlayerHealth>();
        _playerHealth.HealthChanged += _playerMovement.SlowDown;


        var all = FindObjectsOfType<PlayerMovement>();
    }

    private void Update()
    {
        CheckAcceleration();
        
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

    private void CheckAcceleration()
    {
        if (_accelerationTimer >= accelerationDeltaTime)
        {
            _playerMovement.Accelerate();
            _accelerationTimer = 0f;
        }
        else
        {
            _accelerationTimer += Time.deltaTime;
        }
    }
}
