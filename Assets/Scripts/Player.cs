using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private int teamId;
    [SerializeField] private BallOwner ballOwner;
    [SerializeField] private Animator animator;
    private Player player;
    public int TeamId => teamId;
    void Start()
    {
        ballOwner = GetComponentInChildren<BallOwner>();
        player = GetComponent<Player>();
        AnimationRun(false);
    }


    public void AnimationRun(bool state)
    {
        animator.SetBool("BallMe", state);
        if(state == false)
        {
            transform.DOLocalRotate(new Vector3(0, 180, 0),1,RotateMode.Fast);
        }
        else
        {
            transform.DOLocalRotate(new Vector3(0, 0, 0), 1, RotateMode.Fast);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out var ball))
        {
            ballOwner.OwnedBall(ball, ballOwner.RightArm, ballOwner.DownPoint, player);
            AnimationRun(true);
        }
    }
}
