using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int teamId;
    [SerializeField] private BallOwner ballOwner;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    private Player player;
    private Ball ball;
    public int TeamId => teamId;
    void Start()
    {
        ballOwner = GetComponentInChildren<BallOwner>();
        player = GetComponent<Player>();
        AnimationRun(false);
    }
  
    private void Update()
    {
        if (transform.rotation.y == 0)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
           
        }
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
            this.ball = ball;
            ballOwner.OwnedBall(ball, ballOwner.RightArm, ballOwner.DownPoint, player.transform);
            AnimationRun(true);
        }
    }
    private void OnEnable()
    {
        AudioManager.Instance.AudioPlay("Pass");
    }
    private void OnDisable()
    { 
        if(AudioManager.Instance)
        AudioManager.Instance.AudioPlay("PlayerDisactive");
    }
}
