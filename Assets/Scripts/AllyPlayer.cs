using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyPlayer : MonoBehaviour
{
    [SerializeField] private float timeActive;
    private void OnEnable()
    {
        StartCoroutine(CorDisabled());
        IEnumerator CorDisabled()
        {
            yield return new WaitForSeconds(timeActive);
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var ball = other.GetComponent<Ball>();
        if(ball)
        {
            var pl = PrefabsContainer.Instance.PlayerGo;
            pl.transform.position = transform.position;
            pl.gameObject.SetActive(true);
             var ballOwn = pl.GetComponentInChildren<BallOwner>();
            ballOwn.OwnedBall(ball, ballOwn.RightArm, ballOwn.DownPoint,pl.transform);
            gameObject.SetActive(false);
        }
    }
}
