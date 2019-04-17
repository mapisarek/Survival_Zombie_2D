using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject[] animals;

    [Space(3)]
    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;
    
    [Header("(X) Spawn Range")]
    public float xMin;
    public float xMax;

    [Header("(Y) Spawn Range")]
    public float yMin;
    public float yMax;

    public void Update()
    {
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            SpawnAnimals();
            theCountdown = waitingForNextSpawn;
        }
    }

    private void SpawnAnimals()
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        GameObject animalPrefab = animals[Random.Range(0, animals.Length)];
        Instantiate(animalPrefab, pos, transform.rotation);
        //GameObject newGoods = (GameObject)Instantiate(goodsPrefab, pos)
        //newgoods.something = somethingelse;

    }

}
