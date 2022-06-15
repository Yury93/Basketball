using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField] private int betDistance;
    [SerializeField] private Timer timer;
   [SerializeField] private bool stopGame;

    private void Start()
    {
        betDistance = PlayerPrefs.GetInt("BetBonus");
    }
    private void Update()
    {
        if(!stopGame)
        {
            if(betDistance <= CalculatDistance.Instance.Distance)
            {
                AudioManager.Instance.AudioPlay("Win");
                StartCoroutine(CorSceneWin());
                IEnumerator CorSceneWin()
                {
                    timer.TimeTxt.text = "Win!";
                    timer.TimeTxt.color = Color.red;
                    Time.timeScale = 0.3f;
                    timer.enabled = false;
               
                    yield return new WaitForSeconds(1);
                    
                    Time.timeScale = 1f;
                  
                    SceneController.Instance.SceneLoading("BetScene");

                }
                stopGame = true;
            }
        }
    }

}
