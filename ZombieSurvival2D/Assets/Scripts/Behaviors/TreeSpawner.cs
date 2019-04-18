using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    public float radius = 1;
    public Vector2 regionSize = Vector2.one;
    public int rejectionSamples = 30;


    public GameObject tree;
    List<Vector2> points;


    void OnValidate()
    {
        points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);
    }

    void Awake()
    {
        TreeSpawer();
    }

    void TreeSpawer()
    {
        foreach (Vector2 point in points)
        {

            GameObject treeSpawn = Instantiate(tree, point, Quaternion.identity);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
