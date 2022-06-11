using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour
{
    public static event Action <Vector2> OnSwipeEvent;
    private Vector2 tapPosition;
    private Vector2 swipeDelta;

    [SerializeField]private float deadZone = 1f;
    [SerializeField]private bool isMobile;
      [SerializeField]  private bool isSwipe;
    private void Start()
    {
        isMobile = Application.isMobilePlatform;
    }
    private void Update()
    {
        if(!isMobile)
        {
            if(Input.GetMouseButtonDown(0))
            {
                isSwipe = true;
                tapPosition = Input.mousePosition;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                ResetSwipe();
            }
        }
        else
        {
            if(Input.touchCount>0)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    isSwipe = true;
                    tapPosition = Input.GetTouch(0).position;
                }
                else if(Input.GetTouch(0).phase == TouchPhase.Ended ||
                    Input.GetTouch(0).phase == TouchPhase.Canceled)
                {
                    ResetSwipe();
                }
            }
        }
        CheckSwipe();
    }
    private void CheckSwipe()
    {
        swipeDelta = Vector2.zero;

        if (isSwipe)
        {
            if(!isMobile && Input.GetMouseButton(0))
            {
                swipeDelta =(Vector2) Input.mousePosition - tapPosition;
            }
            else if(isMobile)
            {
                swipeDelta = Input.GetTouch(0).position - tapPosition;
            }
        }
        
        if(swipeDelta.magnitude > deadZone)
        {
            swipeDelta.Normalize();
            if(Math.Abs(swipeDelta.x) > Math.Abs(swipeDelta.y))
            {
                OnSwipeEvent?.Invoke(swipeDelta.x > 0 ? Vector2.right : Vector2.left);
            }
            else
            {
                OnSwipeEvent?.Invoke(swipeDelta.y > 0 ? Vector2.up : Vector2.down);
            }
            ResetSwipe();
        }
    }
    private void ResetSwipe()
    {
        isSwipe = false;
        tapPosition = Vector2.zero;
        swipeDelta = Vector2.zero;
    }
}
