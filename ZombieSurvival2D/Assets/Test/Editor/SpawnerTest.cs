using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class SpawnerTest
    {

    IMobSpawner mobSpawner;
    SpawnerGameObjects spawner;
    GameObject animal;

    [SetUp]
    public void InitStats()
    {
        mobSpawner = Substitute.For<IMobSpawner>();
        spawner = new SpawnerGameObjects();
        animal = new GameObject();
        mobSpawner.Animals = new GameObject[] { animal };
        mobSpawner.AnimalAmount = 10;
    }

    
    [Test]
    public void SpawnAnimal_ItsPossible()
    {
        mobSpawner.AnimalCount = 5;
        spawner.SpawnAnimals(mobSpawner);
        Assert.AreEqual(6, mobSpawner.AnimalCount);
    }

    [Test]
    public void SpawningNotPossible_NullException()
    {
        mobSpawner.Animals = null;
        Assert.Throws<NullReferenceException>(() => spawner.SpawnAnimals(mobSpawner));

    }

    [Test]
    public void BlockSpawning_FullAmount()
    {
        mobSpawner.AnimalCount = 10;
        spawner.SpawnAnimals(mobSpawner);
        Assert.AreEqual(mobSpawner.AnimalCount, mobSpawner.AnimalAmount);
    }



}
