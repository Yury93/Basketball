using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnActive : MonoBehaviour
{
    [SerializeField] private float times;
    private void Start()
    {
        Destroy(gameObject, times);
    }
}
