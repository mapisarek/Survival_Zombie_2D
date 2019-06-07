using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshData {

	public List<Vector3> vertices;
	public List<Vector2> UVs;
	public List<int> triangles;

	public MeshData (int x, int y, int width, int height) {

		vertices = new List<Vector3> ();
		UVs = new List<Vector2> ();
		triangles = new List<int> ();

		for (int i = x; i < width + x; i++) {
			for (int j = y; j < height + y; j++) {

				CreateSquare (i, j);
			}
		}
	}

	void CreateSquare (int x, int y) {

		

		Tile tile = World.instance.GetTileAt (x, y);

		vertices.Add (new Vector3(x + 0, y + 0));
		vertices.Add (new Vector3(x + 1, y + 0));
		vertices.Add (new Vector3(x + 0, y + 1));
		vertices.Add (new Vector3(x + 1, y + 1));

		triangles.Add (vertices.Count - 1);
		triangles.Add (vertices.Count - 3);
		triangles.Add (vertices.Count - 4);

		triangles.Add (vertices.Count - 2);
		triangles.Add (vertices.Count - 1);
		triangles.Add (vertices.Count - 4);

		UVs.AddRange (SpriteLoader.instance.GetTileUVs (tile));
	}
}
