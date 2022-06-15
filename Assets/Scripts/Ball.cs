using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speedForward, offsetSpeed;
    [SerializeField] private GameObject buttonPass;
    [SerializeField] private bool menu;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (menu == false)
        {
            if (!parent)
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
                        speedForward * Time.deltaTime, ForceMode.Impulse);
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
        else
        {
            rb.AddForce(Vector3.forward * speedForward* Time.deltaTime, ForceMode.Impulse);
        }
    }
    public void GetParentOwner(Transform player)
    {
        if (player)
        {
            parent = player.transform;
           
        }
        else
        {
            
            Instantiate(PrefabsContainer.Instance.Particl, this.transform.position, Quaternion.identity);
            parent = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var rival = other.GetComponent<Rival>();
        if (rival)
        {
            Destroy(buttonPass);
            var pl = FindObjectOfType<Player>();
            if (pl)
            {
                AudioManager.Instance.AudioPlay("PlayerDisactive");
                Instantiate(PrefabsContainer.Instance.Particl, pl.transform.position, Quaternion.identity);
                Destroy(pl.gameObject);
            }
           
        }
    }
}
