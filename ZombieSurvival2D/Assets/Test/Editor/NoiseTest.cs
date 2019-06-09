using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class NoiseTest
{
    
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


    

}
