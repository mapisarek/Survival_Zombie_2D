using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

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

    // Use this for initialization
    void Awake() {

        instance = this;


        if (randomSeed == true)
        {
            int value = Random.Range(-10000, 10000);
            seed = value.ToString();
        }



        noise = new Noise(seed.GetHashCode(), frequency, amplitude, lecunarity, presistance, octawes);

    }

	void Start () {

		CreateTiles ();
		SubdivideTilesArray ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateTiles () {

		tiles = new Tile[width, height];
        float[,] noiseValues = noise.GetNosiseValues(width, height);
        

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {

                

                if (noiseValues[i,j]>0.5f)
                {
                    tiles[i, j] = new Tile(Tile.Type.Grass);
                }
                else
                {
                    tiles[i, j] = new Tile(Tile.Type.Dirt);

                }
                
			}
		}
	}

	void SubdivideTilesArray (int i1 = 0, int i2 = 0) {

		if (i1 > tiles.GetLength (0) && i2 > tiles.GetLength (1))
			return;

		//Get size of segment
		int sizeX, sizeY;

		if (tiles.GetLength (0) - i1 > 100) {

			sizeX = 100;
		} else
			sizeX = tiles.GetLength (0) - i1;

		if (tiles.GetLength (1) - i2 > 100) {

			sizeY = 100;
		} else
			sizeY = tiles.GetLength (1) - i2;

		GenerateMesh (i1, i2, sizeX, sizeY);

		if (tiles.GetLength (0) > i1 + 100) {
			SubdivideTilesArray (i1 + 100, i2);
			return;
		}

		if (tiles.GetLength (1) > i2 + 100) {
			SubdivideTilesArray (0, i2 + 100);
			return;
		}
	}

	void GenerateMesh (int x, int y, int width, int height) {

		MeshData data = new MeshData (x, y, width, height);

		GameObject meshGO = new GameObject ("CHUNK_" + x + "_" + y);
		meshGO.transform.SetParent (this.transform);

		MeshFilter filter = meshGO.AddComponent<MeshFilter> ();
		MeshRenderer render = meshGO.AddComponent<MeshRenderer> ();
		render.material = material;

		Mesh mesh = filter.mesh;

		mesh.vertices = data.vertices.ToArray ();
		mesh.triangles = data.triangles.ToArray ();
		mesh.uv = data.UVs.ToArray ();
	}

	public Tile GetTileAt (int x, int y) {

		if (x < 0 || x >= width || y < 0 || y >= height) {

			return null;
		}

		return tiles [x, y];
	}
}
