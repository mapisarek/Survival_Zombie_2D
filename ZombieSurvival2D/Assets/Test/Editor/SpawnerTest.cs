using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class SpawnerTest
    {

    [Test]
    public void IsAnimalSpawning()
    {
        var Spawner = Substitute.For<IMobSpawner>();
        SpawnerGameObjects spawnerObjects = new SpawnerGameObjects();
        GameObject animal = new GameObject();
        Spawner.Animals = new GameObject[] { animal };
        Spawner.AnimalAmount = 10;
        Spawner.AnimalCount = 10;

        //Maximum amount of animals, block spawning
        spawnerObjects.SpawnAnimals(Spawner);
        Assert.AreEqual(Spawner.AnimalCount, Spawner.AnimalAmount);

        //Spawning object from array, count < amount
        Spawner.AnimalCount = 5;
        spawnerObjects.SpawnAnimals(Spawner);
        Assert.AreEqual(6, Spawner.AnimalCount);

        //Spawning not possible, null exception
        Spawner.Animals = null;
        Assert.Throws<NullReferenceException>(() => spawnerObjects.SpawnAnimals(Spawner));
    }


}
