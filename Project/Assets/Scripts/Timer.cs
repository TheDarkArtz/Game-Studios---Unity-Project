using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public delegate void TimerEvent();
    public static event TimerEvent OnTimeEnded;

    private float timeRemainingInSecs = 5 * 60;
    private bool ended = false;

    [SerializeField] private TMP_Text timer;


    // Update is called once per frame
    void Update()
    {
        if (timeRemainingInSecs > 0)
        {
            timeRemainingInSecs -= Time.deltaTime;

            float mins = Mathf.FloorToInt(timeRemainingInSecs / 60);
            float secs = Mathf.FloorToInt(timeRemainingInSecs % 60);
            timer.text = $"{mins}:{secs}";
        }
        else
        {
            if(ended == false)
            {
                ended = true;
                OnTimeEnded?.Invoke();
            }
        }
    }
}