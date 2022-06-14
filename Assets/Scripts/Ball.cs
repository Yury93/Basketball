using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speedForward, offsetSpeed;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(!parent)
        {
            if (!joystick.gameObject.activeSelf)
            {
                Timer.Instance.ResetTimer();
               
                //joystick.gameObject.SetActive(true);
                UIController.Instance.OurBall(false);
            }
            else
            {
                var deltaHor = joystick.Horizontal;
                var deltaVert = joystick.Vertical;
              
                rb.AddForce(deltaHor * offsetSpeed,
                    deltaVert * offsetSpeed,
                    speedForward * Time.deltaTime,ForceMode.Impulse);
            }
        }
        else
        {
            if (joystick.gameObject.activeSelf)
            {
                Timer.Instance.ResetTimer();
                joystick.gameObject.SetActive(false);
                UIController.Instance.OurBall(true);
            }
        }
    }
    public void GetParentOwner(Transform player)
    {
        if (player)
            parent = player.transform;
        else
            parent = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        var rival = other.GetComponent<Rival>();
        if (rival)
        {
            var pl = FindObjectOfType<Player>();
            if(pl)
            Destroy(pl.gameObject);
        }
    }
}
