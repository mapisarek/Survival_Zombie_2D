using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

	public enum Type { Dirt, Grass }
	public Type type;

	public Tile (Type type) {

		if (Random.Range (0, 2) == 0) {

			this.type = Type.Dirt;
		} else
			this.type = Type.Grass;
	}

}
