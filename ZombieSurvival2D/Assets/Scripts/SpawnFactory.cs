using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    interface ISpawnFactory
    {
        void SpawnEnemy(GameObject[] enemy, float xMin, float xMax,
            float yMin, float yMax);
    }


    class AnimalFactory : MonoBehaviour, ISpawnFactory
    {
        public void SpawnEnemy(GameObject[] enemy, float xMin, float xMax, float yMin, float yMax)
        {
            Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), -1);
            GameObject animalPrefab = enemy[Random.Range(0, enemy.Length)];
            Instantiate(animalPrefab, pos, Quaternion.Euler(0, 0, 0));
        }
    }

    class EnemyFactory : MonoBehaviour, ISpawnFactory
    {
        public void SpawnEnemy(GameObject[] enemy, float xMin, float xMax, float yMin, float yMax)
        {
            Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            GameObject monsterPrefab = enemy[Random.Range(0, enemy.Length)];
            Instantiate(monsterPrefab, pos, Quaternion.Euler(0, 0, 0));
        }
    }

}
