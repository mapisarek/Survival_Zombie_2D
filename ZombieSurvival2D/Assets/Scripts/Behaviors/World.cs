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



    public GameObject tree;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public GameObject autumn_tree;

    public GameObject stone;
    public GameObject resource_stone;
    public GameObject resource_stone2;
    public GameObject iron_stone;
    public GameObject gold_stone;
    public GameObject Ice_Block_v1;
    public GameObject Ice_Block_v2;
    public GameObject Ice_Block_v3;

    // Use this for initialization


    void Awake()
    {

        instance = this;


        if (randomSeed == true)
        {
            int value = Random.Range(0, 10000);
            seed = value.ToString();
        }



        noise = new Noise(seed.GetHashCode(), frequency, amplitude, lecunarity, presistance, octawes);

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
        float z = -1;
        var pozycja = new Vector3(x, y,z);
        int value = Random.Range(0, 100);
        int R = Random.Range(0, 5);
        if (wysokosc >= grassStartHeight && wysokosc <= grassEndHeight && value >= 80)
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
                GameObject stonespawn = Instantiate(stone, pozycja, Quaternion.identity);
                stonespawn.transform.SetParent(this.transform);



            }
        }
        if (wysokosc >= grass2StartHeight && wysokosc <= grass2EndHeight && value >= 90)
        {
            GameObject treegrass2Spawn = Instantiate(autumn_tree, pozycja, Quaternion.identity);
            treegrass2Spawn.transform.SetParent(this.transform);

        }
        if (wysokosc >= grass2StartHeight && wysokosc <= grass2EndHeight && value == 50)
        {
            GameObject stonespawn = Instantiate(stone, pozycja, Quaternion.identity);
            stonespawn.transform.SetParent(this.transform);

        }


            
        if (wysokosc >= stoneStartHeight && wysokosc <= stoneEndHeight && value >= 92)
        {
            if (R == 0)
            {
                GameObject stoneSpawn = Instantiate(resource_stone, pozycja, Quaternion.identity);
                stoneSpawn.transform.SetParent(this.transform);
            }
            if (R == 1)
            {
                GameObject stoneSpawn = Instantiate(resource_stone2, pozycja, Quaternion.identity);
                stoneSpawn.transform.SetParent(this.transform);

            }
            if (R == 2)
            {
                GameObject stoneSpawn = Instantiate(iron_stone, pozycja, Quaternion.identity);
                stoneSpawn.transform.SetParent(this.transform);


            }
            if (R == 3)
            {
                GameObject stoneSpawn = Instantiate(gold_stone, pozycja, Quaternion.identity);
                stoneSpawn.transform.SetParent(this.transform);

            }

        }
        if (wysokosc >= snowStartHeight && wysokosc <= snowEndHeight && value >= 90)
        {
            if (R == 0)
            {
                GameObject IceSpawn = Instantiate(Ice_Block_v1, pozycja, Quaternion.identity);
                IceSpawn.transform.SetParent(this.transform);

            }
            if (R == 1)
            {
                GameObject IceSpawn = Instantiate(Ice_Block_v2, pozycja, Quaternion.identity);
                IceSpawn.transform.SetParent(this.transform);

            }
            if (R == 2)
            {
                GameObject IceSpawn = Instantiate(Ice_Block_v3, pozycja, Quaternion.identity);
                IceSpawn.transform.SetParent(this.transform);

            }
        }





    }
}
