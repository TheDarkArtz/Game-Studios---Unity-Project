using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemainingInSecs = 300;
    public Text timer;

    // Update is called once per frame
    void Update()
    {
        if (timeRemainingInSecs > 0)
        {
            timeRemainingInSecs -= Time.deltaTime;
        }
        else
        {
            timeRemainingInSecs = 300;
        }
        Lookie(timeRemainingInSecs);
    }
    void Lookie(float showingTime)
    {
        if(showingTime < 0)
        {
            showingTime = 0;
        }

        float mins = Mathf.FloorToInt(showingTime / 60);
        float secs = Mathf.FloorToInt(showingTime % 60);

        timer.text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}:{4:00}:{5:00}", mins, secs);
    }
}
