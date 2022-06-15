using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Rival : MonoBehaviour
{
    [SerializeField] private BallOwner ballOwnerRival;
    public BallOwner OwnerRival => ballOwnerRival;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeLives;
    [SerializeField] private bool menu;
    private void OnEnable()
    {
        transform.DOLocalRotate(new Vector3(0, 180, 0), 1, RotateMode.Fast);
        StartCoroutine(CorStart());
        IEnumerator CorStart()
        {
            yield return new WaitForSeconds(timeLives);
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Ball>(out var ball))
        {
            ballOwnerRival.OwnedBall(ball, ballOwnerRival.RightArm, ballOwnerRival.DownPoint, this.gameObject.transform);
            animator.SetBool("BallMe", true);
            if (!menu)
            {
                Timer.Instance.StopTimer();
            }
            return;
        }
    }
}
