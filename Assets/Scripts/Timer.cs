using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : SingletonBase<Timer>
{
    [SerializeField] private float timer;
    private float startTimer;
    [SerializeField] private Text timeTxt;
    [SerializeField] private bool pass,timerStop;
    private void Start()
    {
        startTimer = timer;
    }
    public void StopTimer()
    {
        timerStop = true;
    }
    public void ResetTimer()
    {
        timer = startTimer;
        if(pass)
        {
            pass = false;
        }
        else
        {
            pass = true;
        }
    }
    public void Update()
    {
        if (!timerStop)
        {
            if (timer <= 0)
            {
                timeTxt.text = "Time's up!";
                StartCoroutine(CorStopGame());
                IEnumerator CorStopGame()
                {
                    yield return new WaitForSeconds(1f);
                    timerStop = true;
                }
            }
            else
            {
                timer -= Time.deltaTime;
                timeTxt.text = $"Time:{(int)timer}";
                if (timer < 5)
                {
                    if (pass)
                    {
                        timeTxt.text = $"Time:{(int)timer}\n We have to give up the pass right away!";
                    }
                    else
                    {
                        timeTxt.text = $"Time:{(int)timer}\n We have to give the ball to a player urgently!";
                    }
                }
            }
        }
        else
        {
            timeTxt.color = Color.red;
            timeTxt.text = $"You lost a half, but not the whole game!";
        }
    }
}
