using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAllyPlayers : PoolObjects<AllyPlayer>
{
    [SerializeField] private Player player;
    [SerializeField] private float time;
    private float startTime;
    private void Start()
    {
        startTime = time;
    }
    private void Update()
    {
        if (player.gameObject.activeSelf)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                int x = Random.Range(-2, 2);
                int z = Random.Range(10, 22);
                if(x == 1 || x == -1) { x = 0; }
                GetVectorSpawn(new Vector3(player.transform.position.x + x,
                    player.transform.position.y,
                    player.transform.position.z+z));
                GetFreeElement();
                time = startTime;
            } 
        }
    }
}
