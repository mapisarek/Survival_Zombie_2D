using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

	public enum Type { Dirt, Grass,Grass2,Water,Stone,Snow,Sand,Sand2,Void }
	public Type type;

	public Tile (Type type)
    {
        this.type = type;
		
	}

}
