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
    public Ball GetBall => ball;
    [SerializeField]private float offsetSize;
    [SerializeField] private Collider playerCollider;
    [SerializeField] private Player player;
    [SerializeField] private float offsetZ;

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
    public void OwnedBall(Ball ball, Transform rightArm, Transform downPoint,Transform parent)
    {
        this.rightArm = rightArm;
        this.downPoint = downPoint;
        this.ball = ball;
        ball.transform.parent = parent;
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
                new Vector3(offsetSize, 0,0), 0.2f);
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
            ball.transform.DOMove(new Vector3(rightArm.position.x,rightArm.position.y,rightArm.position.z + offsetZ), 0.2f);
        }
        else
        {
            return;
        }
    }
}