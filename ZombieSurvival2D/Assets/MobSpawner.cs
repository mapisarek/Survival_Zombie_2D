using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject[] animals;

    [Space(3)]
    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;
    
    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;

    public void Update()
    {
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            SpawnGoodies();
            theCountdown = waitingForNextSpawn;
        }
    }

    private void SpawnGoodies()
    {

    }

}
