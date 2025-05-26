using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using System.Threading.Tasks;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] public int timeInSeconds;
    private int timeSeconds;

    private bool timerInit;
    private float secondsMeter;
    private int secondsMeterInt;
    private int lastSeconds;
    private TMP_Text timerText;
    private Animator animator;

    void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        animator = GetComponent<Animator>();}

    void Update()
    {

        if (timerInit)
        {
            secondsMeter += Time.deltaTime;
            secondsMeterInt = Convert.ToInt32(MathF.Round(secondsMeter));


            lastSeconds = timeSeconds - secondsMeterInt;
            //   Debug.Log($"secondsMeter:{secondsMeter}\nsecondsMeterInt:{secondsMeterInt}\nlastSeconds:{lastSeconds}");
            timerText.text = SecondsToTime(lastSeconds);
            if (lastSeconds <= 0)
            {
                timerText.text = "";
                timerInit = false;
                timeSeconds = 0;
                animator.enabled = false;
            }


        }
            

    }
    public void StartTimer(int timeInSeconds)
    {
        animator.enabled = true;
        animator.Play("Pulse");
        timeSeconds = timeInSeconds;
        timerInit = true;
        secondsMeter = 0;
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
    //IEnumerator Pulse() {

}
