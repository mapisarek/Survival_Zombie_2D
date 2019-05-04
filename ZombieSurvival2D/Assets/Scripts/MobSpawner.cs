using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject[] animals;

    [Space(3)]
    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;
    public float animalAmount = 15;
    
    [Header("(X) Spawn Range")]
    public float xMin;
    public float xMax;

    [Header("(Y) Spawn Range")]
    public float yMin;
    public float yMax;

    private float animalCount;

    public void Update()
    {
        TimeCounter();
    }

    private void TimeCounter()
    {
        if (animalCount < animalAmount)
        {
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            SpawnAnimals();
            theCountdown = waitingForNextSpawn;
        }
        }
    }

    private void SpawnAnimals()
    {
        if(animalCount < animalAmount)
        {
            Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), -1);
            GameObject animalPrefab = animals[Random.Range(0, animals.Length)];
            Instantiate(animalPrefab, pos, transform.rotation);
            animalCount++;
        }
        
    }

}
