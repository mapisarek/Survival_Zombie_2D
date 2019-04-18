using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    public float radius = 1;
    public Vector2 regionSize = Vector2.one;
    public int rejectionSamples = 30;


    public GameObject tree;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public GameObject tree5;
    public GameObject tree6;


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
        foreach (Vector3 point in points)
        {
           int value= Random.Range(0,5);
            if (value==0)
            {
            GameObject treeSpawn = Instantiate(tree, point, Quaternion.identity);
            treeSpawn.transform.SetParent(this.transform);
            }
            if (value==1)
            {
                GameObject treeSpawn = Instantiate(tree2, point, Quaternion.identity);
                treeSpawn.transform.SetParent(this.transform);
            }
            if (value==2)
            {
                GameObject treeSpawn = Instantiate(tree3, point, Quaternion.identity);
                treeSpawn.transform.SetParent(this.transform);
            }
            if (value==3)
            {
                GameObject treeSpawn = Instantiate(tree4, point, Quaternion.identity);
                treeSpawn.transform.SetParent(this.transform);
            }
            if (value==4)
            {
                GameObject treeSpawn = Instantiate(tree5, point, Quaternion.identity);
                treeSpawn.transform.SetParent(this.transform);
            }
            if (value==5)
            {
                GameObject treeSpawn = Instantiate(tree6, point, Quaternion.identity);
                treeSpawn.transform.SetParent(this.transform);
            }
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
