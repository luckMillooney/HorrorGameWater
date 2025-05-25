using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] public int timeInSeconds;
    private int timeSeconds;
    public TMP_Text timerText;
    private bool timerInit;
    private float secondsMeter;
    private int secondsMeterInt;
    private int lastSeconds;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerInit)
        {
            secondsMeter += Time.deltaTime;
            secondsMeterInt = Convert.ToInt32(MathF.Round(secondsMeter));
            lastSeconds = timeSeconds - secondsMeterInt;
            // Debug.Log($"secondsMeter:{secondsMeter}\nsecondsMeterInt:{secondsMeterInt}\nlastSeconds:{lastSeconds}");
            timerText.text = SecondsToTime(lastSeconds);
            if (lastSeconds <= 0)
            {
                timerText.text = "";
                timerInit = false;
                timeSeconds = 0;
            }

            
        }
        
    }
    public void StartTimer(int timeInSeconds)
    {
        timeSeconds = timeInSeconds;
        timerInit = true;
    }

    private string SecondsToTime(int fullSeconds)
    {
        int seconds = fullSeconds % 60;
        decimal minuteRaw = Convert.ToDecimal(fullSeconds / 60);
        int minute = (int)Math.Round(minuteRaw);
        if (minute >= 1)
        {
            if (seconds >= 10)
            {
                return $"{minute}:{seconds}";
            }
            return $"{minute}:0{seconds}";
        }
        return $"{seconds}";
    }
}
