using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIController : SingletonBase<UIController>
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Swiper swiper;
    [SerializeField] private Button buttonPass;
    private void Start()
    {
        OurBall(false);
    }

    public void OurBall(bool state)
    {
        if(state)
        {
            joystick.gameObject.SetActive(false);
        }
        else
        {
            joystick.gameObject.SetActive(true);
        }
        buttonPass.gameObject.SetActive(state);
        swiper.gameObject.SetActive(state);
    }
}
