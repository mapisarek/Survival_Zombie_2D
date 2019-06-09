using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Noise

{
    int seed;

    float frequency;
    float amplitude;

    float lecunarity;
    float presistance;

    int octawes;

    public Noise(int seed,float frequency, float amplitude, float lecunarity, float presistance, int octawes)
    {
        this.seed = seed;
        this.frequency = frequency;
        this.amplitude = amplitude;
        this.lecunarity = lecunarity;
        this.presistance = presistance;
        this.octawes = octawes;
     
    }

  

    public float[,] GetNosiseValues(int width, int height)
    {
        float[,] noiseValues = new float[width, height];
        float max = 0f;
        float min = float.MaxValue;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                noiseValues[i, j] = 0f;

                float tempA = amplitude;
                float tempF = frequency;

                for (int k = 0; k < octawes; k++)
                {
                    noiseValues[i, j] += Mathf.PerlinNoise((i +seed)/ (float)width*frequency, j / (float)height * frequency)*amplitude;
                    frequency *= lecunarity;
                    amplitude *= presistance;
                }
                amplitude = tempA;
                frequency = tempF;

                if (noiseValues[i,j]>max)
                {
                    max = noiseValues[i,j];
                }
                if (noiseValues[i,j]<min)
                {
                    min = noiseValues[i, j];
                }
            }
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                noiseValues[i, j] = Mathf.InverseLerp(max, min, noiseValues[i, j]);
            }
        }
        return noiseValues;
    }

}

    
