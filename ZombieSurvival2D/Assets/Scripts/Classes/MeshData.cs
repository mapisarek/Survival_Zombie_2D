using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MeshData
{
   public List<Vector3> vertices;
    public List<int> triangles;
    public MeshData(Tile[,]data)
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                CreateSquare(data[i, j], i, j);
            }
        }
    }
    void CreateSquare(Tile tile,int x, int y)
    {
        vertices.Add(new Vector3(x + 0, y + 0));
        vertices.Add(new Vector3(x + 1, y + 0));
        vertices.Add(new Vector3(x + 0, y + 1));
        vertices.Add(new Vector3(x + 1, y + 1));

        triangles.Add(vertices.Count - 1);
        triangles.Add(vertices.Count - 3);
        triangles.Add(vertices.Count - 4);


        triangles.Add(vertices.Count - 2);
        triangles.Add(vertices.Count - 1);
        triangles.Add(vertices.Count - 4);

    }

}

