using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile 
{
   public enum Type { Stone}
    public Type type;
    public Tile(Type type)
    {
        Debug.Log("Creating tile of type" + type.ToString());
        this.type = type;
    }
}

