using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class InputMove : MonoBehaviour
{
    [SerializeField] private Floor floorPoint;
    private void Start()
    {
        Swiper.OnSwipeEvent += Swiper_OnSwipeEvent;
    }
    private void Swiper_OnSwipeEvent(Vector2 dir)
    {
        if(dir == Vector2.right)
        {
            if (transform.position.x < floorPoint.RightPoint.position.x)
            {
                transform.DOMoveX(transform.position.x + Vector3.right.x *2, 1);
                return;
            }
        }
        if (dir == Vector2.left)
        {
            if (transform.position.x > floorPoint.LeftPoint.position.x)
            {
                transform.DOMoveX(transform.position.x + Vector3.left.x * 2, 1);
                return;
            }
        }
    }
}
