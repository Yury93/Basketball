using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private Transform leftPoint, rightPoint;

    public Transform RightPoint => rightPoint;
    public Transform LeftPoint => leftPoint;
    [SerializeField] private bool startFloor;
    [SerializeField] private float timeActive;
    [SerializeField] private MeshRenderer material;
    [SerializeField] private Material color1, color2;
    private void OnEnable()
    {
        if (this.material.sharedMaterial == color2)
        {
           this. material.sharedMaterial= color1;
        }
        else
        {
           this. material.sharedMaterial = color2;
        }
        if (!startFloor)
        {
            StartCoroutine(CorDisabled());
            IEnumerator CorDisabled()
            {
                yield return new WaitForSeconds(timeActive);
                gameObject.SetActive(false);
            }
        }
    }
  
    private void OnTriggerEnter(Collider other)
    {
        var b = other.GetComponent<Ball>();
        if(b)
        {
            PoolFloor.instance.GetNewVector( new Vector3(transform.position.x,
                transform.position.y,
                transform.position.z + 21.91f));
            PoolFloor.instance.GetFreeFloor();
        }
    }
}

