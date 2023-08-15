using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField][FormerlySerializedAs("Time Limit")] 
    private float currentTime = 100.0f;
    
    private Slider _countDownTimer;
    private TMP_Text _countDownText;

    public bool TimeIsUp => currentTime <= 0;

    private void Awake()
    {
        _countDownTimer = GetComponent<Slider>();
        _countDownTimer.maxValue = currentTime;

        _countDownText = GetComponentInChildren<TMP_Text>();
        _countDownText.text = ToDisplayTime(currentTime);
    }

    private void Update()
    {
        GameTick();
    }

    private void GameTick()
    {
        if (!TimeIsUp)
        {
            currentTime -= Time.deltaTime;
            
            _countDownTimer.value = currentTime;
            _countDownText.text = ToDisplayTime(currentTime);
        }
        else
        {
            currentTime = 0;
        }
    }
    
    private static string ToDisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return timeToDisplay > 0
            ? $"{minutes:00}:{seconds:00}"
            : "Time is up!";
    }
}
