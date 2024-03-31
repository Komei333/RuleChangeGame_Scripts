using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] MainManager mainManager;
    [SerializeField] Text timeText;

    public float second = 60;

    private bool start = false;
    private bool finish = false;

    void Update()
    {
        UpdateTime();
        CheckTime();
    }

    private void UpdateTime()
    {
        if(start == false)
        {
            timeText.text = "00:00";
        }
        else
        {
            second -= Time.deltaTime;
            timeText.text = "00:" + ((int)second).ToString("00");
        }
    }

    private void CheckTime()
    {
        if(second < 1.0 && finish == false)
        {
            mainManager.OpenScore();
            finish = true;
        }
    }

    public void TimerStart()
    {
        start = true;
    }
}
