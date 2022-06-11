using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolFloor : PoolObjects<Floor>
{
    public static PoolFloor instance;
    private void Start()
    {
        instance = GetComponent<PoolFloor>();
    }
    public void GetNewVector(Vector3 pos)
    {
        GetVectorSpawn(pos);
    }
    public void GetFreeFloor()
    {
        GetFreeElement();
    }
}
