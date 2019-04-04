using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class World : MonoBehaviour
{
    public int width;
    public int height;

    public Tile[,] tiles;

    // Start is called before the first frame update
    void Start()
    {
        CreateTiles();
        GenerateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateTiles()
    {
        tiles = new Tile[width,height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                tiles[i, j] = new Tile(Tile.Type.Stone);
            }
        }
    }

    void GenerateMesh()
    {
        MeshData data = new MeshData(tiles);

        GameObject meshGO = new GameObject("CHUNK");
        MeshFilter filter = meshGO.AddComponent<MeshFilter>();
        meshGO.AddComponent<MeshRenderer>();

        Mesh mesh = filter.mesh;

        mesh.vertices = data.vertices.ToArray();
        mesh.triangles = data.triangles.ToArray();
    }

}
