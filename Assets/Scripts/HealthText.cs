using Player;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private TMP_Text _healthText;
    
    private void Awake()
    {
        _healthText = GetComponent<TMP_Text>();
        
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _playerHealth.HealthChanged += UpdateCurrentHealth;
    }

    private void Start()
    {
        UpdateCurrentHealth();
    }

    private void UpdateCurrentHealth()
    {
        _healthText.text = _playerHealth.Health.ToString();
    }
}
