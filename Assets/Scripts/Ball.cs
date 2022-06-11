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
                //joystick.gameObject.SetActive(true);
                UIController.Instance.OurBall(false);
            }
            else
            {
                rb.AddForce(joystick.Horizontal * offsetSpeed,
                    joystick.Vertical * offsetSpeed,
                    speedForward * Time.deltaTime,ForceMode.Impulse);
            }
        }
        else
        {
            if (joystick.gameObject.activeSelf)
            {
                joystick.gameObject.SetActive(false);
                UIController.Instance.OurBall(true);
            }
        }
    }
    public void GetParentOwner(Player player)
    {
        if (player)
            parent = player.transform;
        else
            parent = null;
    }
}
