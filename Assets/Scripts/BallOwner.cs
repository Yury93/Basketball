using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class BallOwner : MonoBehaviour
{
    #region Properties
    [SerializeField] private Transform rightArm;
    public Transform RightArm => rightArm;
    [SerializeField] private Transform downPoint;
    public Transform DownPoint => downPoint;
    [SerializeField] private Ball ball;
    [SerializeField]private float offsetSize;
    [SerializeField] private Collider playerCollider;
    [SerializeField] private Player player;

    #endregion
    private void OnEnable()
    {
        playerCollider.enabled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ball"></param>
    /// <param name="rightArm"></param>
    /// <param name="downPoint"></param>
    /// <param name="parent"></param>
    public void OwnedBall(Ball ball, Transform rightArm, Transform downPoint,Player parent)
    {
        this.rightArm = rightArm;
        this.downPoint = downPoint;
        this.ball = ball;
        ball.transform.parent = gameObject.GetComponentInParent<InputMove>().transform;
        ball.GetParentOwner(parent);
    }
    public void Pass()
    {
        ball.transform.parent = null;
        ball.GetParentOwner(null);
        ball = null;
        playerCollider.enabled = false;
        player.AnimationRun(false);
        GetComponentInParent<Player>().gameObject.SetActive(false);
    }
    public void EventAnimationOwnerDown()
    {
        if (ball)
        {
            ball.transform.DOMove(downPoint.position + 
                new Vector3(offsetSize, 0,0), 0.25f);
        }
        else
        {
            return;

        }
    }
    public void EventAnimationOwnerUp()
    {
        if (ball)
        {
            ball.transform.DOMove(rightArm.position, 0.2f);
        }
        else
        {
            return;
        }
    }
}