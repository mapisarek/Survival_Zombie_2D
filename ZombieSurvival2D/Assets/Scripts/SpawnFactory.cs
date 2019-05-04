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

   

}
