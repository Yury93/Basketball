using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAllyPlayers : PoolObjects<AllyPlayer>
{
    [SerializeField] private Ball ball;
    [SerializeField] private float time;
    private float startTime;
    private void Start()
    {
        startTime = time;
    }
    private void Update()
    {
        if (ball.gameObject.activeSelf)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                int x = RandomizeInt(-3, 3);
                int z = Random.Range(10, 22);
                GetVectorSpawn(new Vector3(x,
                    -0.59f,
                    ball.transform.position.z + z));
                GetFreeElement();
                time = startTime;
            } 
        }
    }
    private int RandomizeInt(int min, int max)
    {
        int x = Random.Range(min, max);
        if (x == 0 || x == 2 || x == -2)
        {
            return x;
        }
        else
        {
            while (true)
            {
                x = RandomizeInt(min, max);
                if (x == 0 || x == 2 || x == -2)
                {
                    return x;
                    break;
                }
            }
        }
    }
}
