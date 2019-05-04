using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] animals;
        public GameObject[] monsters;

        [Space(3)]
        public float waitingForNextSpawn = 10;
        public float theCountdown = 10;
        public float animalAmount = 15;
        public float monstersAmount = 15;

        [Header("(X) Spawn Range")]
        public float xMin;
        public float xMax;

        [Header("(Y) Spawn Range")]
        public float yMin;
        public float yMax;

        protected float animalCount;
        protected float monstersCount;
        private AnimalFactory animalFactory;
        private EnemyFactory enemyFactory;

        public void Start()
        {
            animalFactory = new AnimalFactory();
            enemyFactory = new EnemyFactory();

        }

        public void Update()
        {
            InitializeSpawn();
        }

        private void CreateMobs()
        {
            if (animalCount < animalAmount)
            {
                animalFactory.SpawnEnemy(animals, xMin, xMax, yMin, yMax);
                animalCount++;
            }
            if (monstersCount < monstersAmount)
            {
                animalFactory.SpawnEnemy(animals, xMin, xMax, yMin, yMax);
                monstersCount++;
            }
        }

        private void InitializeSpawn()
        {
                theCountdown -= Time.deltaTime;
                if (theCountdown <= 0)
                {
                    CreateMobs();
                    theCountdown = waitingForNextSpawn;
                }

        }
    }

}
