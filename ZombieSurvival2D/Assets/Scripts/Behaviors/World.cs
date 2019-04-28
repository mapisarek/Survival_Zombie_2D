using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public static World instance;

    public Material material;

    public string seed;
    public bool randomSeed;
    public int width;
    public int height;

    public Tile[,] tiles;

    public float frequency;
    public float amplitude;

    public float lecunarity;
    public float presistance;

    public int octawes;

    Noise noise;

    public float seaLevel;

    public float beachStartHeight;
    public float beachEndHeight;

    public float beach2StartHeight;
    public float beach2EndHeight;

    public float dirtStartHeight;
    public float dirtEndHeight;

    public float grassStartHeight;
    public float grassEndHeight;

    public float grass2StartHeight;
    public float grass2EndHeight;

    public float stoneStartHeight;
    public float stoneEndHeight;

    public float snowStartHeight;
    public float snowEndHeight;






    List<Vector2> points;
    public float radius = 1;
    public Vector2 regionSize = Vector2.one;
    public int rejectionSamples = 30;


    public GameObject tree;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public GameObject tree5;
    public GameObject tree6;
    // Use this for initialization


    void Awake()
    {

        instance = this;


        if (randomSeed == true)
        {
            int value = Random.Range(-10000, 10000);
            seed = value.ToString();
        }



        noise = new Noise(seed.GetHashCode(), frequency, amplitude, lecunarity, presistance, octawes);
        //TreeSpawer();
    }
    void OnValidate()
    {
        points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);
    }

    void Start()
    {

        CreateTiles();
        SubdivideTilesArray();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateTiles()
    {

        tiles = new Tile[width, height];
        float[,] noiseValues = noise.GetNosiseValues(width, height);

        Debug.Log(noiseValues[10, 10]);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {

                tiles[i, j] = MakeTileAtHeight(noiseValues[i, j]);
                TreeSpawer(noiseValues[i, j], i, j);



                //GameObject treeSpawn = Instantiate(tree, value, Quaternion.identity);


            }
        }
    }
    
    Tile MakeTileAtHeight(float currentHeight)
    {
        if (currentHeight <= seaLevel)
        {
            return new Tile(Tile.Type.Water);
        }
        if (currentHeight >= beachStartHeight && currentHeight <= beachEndHeight)
        {
            return new Tile(Tile.Type.Sand);
        }
        if (currentHeight >= beach2StartHeight && currentHeight <= beach2EndHeight)
        {
            return new Tile(Tile.Type.Sand2);
        }
        if (currentHeight >= dirtStartHeight && currentHeight <= dirtEndHeight)
        {
            return new Tile(Tile.Type.Dirt);
        }
        if (currentHeight >= grassStartHeight && currentHeight <= grassEndHeight)
        {
            return new Tile(Tile.Type.Grass);
        }
        if (currentHeight >= grass2StartHeight && currentHeight <= grass2EndHeight)
        {
            return new Tile(Tile.Type.Grass2);
        }
        if (currentHeight >= stoneStartHeight && currentHeight <= stoneEndHeight)
        {
            return new Tile(Tile.Type.Stone);
        }
        if (currentHeight >= snowStartHeight && currentHeight <= snowEndHeight)
        {
            return new Tile(Tile.Type.Snow);
        }

        return new Tile(Tile.Type.Void);
    }


    void SubdivideTilesArray(int i1 = 0, int i2 = 0)
    {

        if (i1 > tiles.GetLength(0) && i2 > tiles.GetLength(1))
            return;

        //Get size of segment
        int sizeX, sizeY;

        if (tiles.GetLength(0) - i1 > 100)
        {

            sizeX = 100;
        }
        else
            sizeX = tiles.GetLength(0) - i1;

        if (tiles.GetLength(1) - i2 > 100)
        {

            sizeY = 100;
        }
        else
            sizeY = tiles.GetLength(1) - i2;

        GenerateMesh(i1, i2, sizeX, sizeY);

        if (tiles.GetLength(0) > i1 + 100)
        {
            SubdivideTilesArray(i1 + 100, i2);
            return;
        }

        if (tiles.GetLength(1) > i2 + 100)
        {
            SubdivideTilesArray(0, i2 + 100);
            return;
        }
    }

    void GenerateMesh(int x, int y, int width, int height)
    {

        MeshData data = new MeshData(x, y, width, height);

        GameObject meshGO = new GameObject("CHUNK_" + x + "_" + y);
        meshGO.transform.SetParent(this.transform);

        MeshFilter filter = meshGO.AddComponent<MeshFilter>();
        MeshRenderer render = meshGO.AddComponent<MeshRenderer>();
        render.material = material;

        Mesh mesh = filter.mesh;

        mesh.vertices = data.vertices.ToArray();
        mesh.triangles = data.triangles.ToArray();
        mesh.uv = data.UVs.ToArray();
    }

    public Tile GetTileAt(int x, int y)
    {

        if (x < 0 || x >= width || y < 0 || y >= height)
        {

            return null;
        }

        return tiles[x, y];
    }

    void TreeSpawer(float wysokosc, int x, int y)
    {
        var pozycja = new Vector2(x, y);
        int value = Random.Range(0, 100);
        int R = Random.Range(0, 5);
        if (wysokosc >= grassStartHeight && wysokosc <= grassEndHeight && value <= 5)
        {

            if (R == 0)
            {
                GameObject treeSpawn = Instantiate(tree, pozycja, Quaternion.identity);
                treeSpawn.transform.SetParent(this.transform);
            }
            if (R == 1)
            {
                GameObject treeSpawn = Instantiate(tree2, pozycja, Quaternion.identity);
                treeSpawn.transform.SetParent(this.transform);

            }
            if (R == 2)
            {
                GameObject treeSpawn = Instantiate(tree3, pozycja, Quaternion.identity);
                treeSpawn.transform.SetParent(this.transform);

            }
            if (R == 3)
            {
                GameObject treeSpawn = Instantiate(tree4, pozycja, Quaternion.identity);
                treeSpawn.transform.SetParent(this.transform);

            }
            if (R == 4)
            {
                GameObject treeSpawn = Instantiate(tree5, pozycja, Quaternion.identity);
                treeSpawn.transform.SetParent(this.transform);

            }


        }
    }



}
