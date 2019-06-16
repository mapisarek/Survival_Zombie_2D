using UnityEngine;

public interface IMobSpawner
{
    float AnimalAmount { get; set; }
    float AnimalCount { get; set; }
    GameObject[] Animals { get; set; }
    GameObject[] Monsters { get; set; }
    Vector3 Pos { get; set; }
    float XMax { get; set; }
    float XMin { get; set; }
    float YMax { get; set; }
    float YMin { get; set; }
}