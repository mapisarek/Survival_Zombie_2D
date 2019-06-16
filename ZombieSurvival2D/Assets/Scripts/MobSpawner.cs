using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour, IMobSpawner
{
    private GameObject[] animals;
    private GameObject[] monsters;

    [Space(3)]
    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;
    private float animalAmount = 15;
    public float monstersAmount = 15;

    [Header("(X) Spawn Range")]
    private float xMin;
    private float xMax;

    [Header("(Y) Spawn Range")]
    private float yMin;
    private float yMax;

    private float animalCount;
    private float monstersCount;

    public float AnimalCount { get => animalCount; set => animalCount = value; }
    public float AnimalAmount { get => animalAmount; set => animalAmount = value; }
    public GameObject[] Animals { get => animals; set => animals = value; }
    public GameObject[] Monsters { get => monsters; set => monsters = value; }
    public float YMin { get => yMin; set => yMin = value; }
    public float YMax { get => yMax; set => yMax = value; }
    public float XMin { get => xMin; set => xMin = value; }
    public float XMax { get => xMax; set => xMax = value; }
    public Vector3 Pos { get; set; }


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
        if (animalCount < animalAmount)
        {
            Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), -1);
            GameObject animalPrefab = animals[Random.Range(0, animals.Length)];
            Instantiate(animalPrefab, pos, Quaternion.identity);
            animalCount++;
        }

    }



}

public class SpawnerGameObjects
{
    public void SpawnAnimals(IMobSpawner mobSpawner)
    {
        if (mobSpawner.AnimalCount < mobSpawner.AnimalAmount)
        {
            mobSpawner.Pos = new Vector3(Random.Range(mobSpawner.XMin, mobSpawner.XMax), Random.Range(mobSpawner.YMin, mobSpawner.YMax), -1);
            GameObject animalPrefab = mobSpawner.Animals[Random.Range(0, mobSpawner.Animals.Length)];
            GameObject.Instantiate(animalPrefab, mobSpawner.Pos, Quaternion.identity);
            mobSpawner.AnimalCount++;
        }
    }
}
