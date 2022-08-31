using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
   
    public Text timerText;
    public void UpdateTime(float currentTime)
    {
        string displayTime = Mathf.Floor(currentTime).ToString();
        timerText.text = displayTime;
    }
}
