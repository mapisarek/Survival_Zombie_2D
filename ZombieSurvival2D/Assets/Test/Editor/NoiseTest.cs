using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class NoiseTest
{
    [TestCase(1, 1, 1, 1, 1, 1)]
    [TestCase(0, 0, 2, 1, 1, 1)]
    [TestCase(0, 0, 0, 0, 0, 0)]
    [TestCase(10,5, 0, 0, 0, 0)]
    [TestCase(1, 8, 5, 1,0,6)]

    public void SeedIsGreatherOrEqualThanZero(int seed, float frequency, float amplitude, float lecunarity, float presistance, int octawes)
    {
        var n = new Noise(seed, frequency, amplitude, lecunarity, presistance, octawes);

        Assert.GreaterOrEqual(seed, 0);
        Assert.GreaterOrEqual(frequency, 0);
        Assert.GreaterOrEqual(amplitude, 0);
        Assert.GreaterOrEqual(lecunarity, 0);
        Assert.GreaterOrEqual(presistance, 0);
        Assert.GreaterOrEqual(octawes, 0);
    }

    public void NoiseValueAreNotZero(int seed, float frequency, float amplitude, float lecunarity, float presistance, int octawes, float width, float height, int i, int j)
    {
        double noiseValueX = (i + seed) / width * frequency;
        double noiseValueY = j / height * frequency * amplitude;

        Assert.GreaterOrEqual(noiseValueX, 0);
        Assert.GreaterOrEqual(noiseValueY, 0);
    }



}
