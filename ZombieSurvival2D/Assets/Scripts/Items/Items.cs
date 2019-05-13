using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]

public class Items : ScriptableObject
{
    new public string name = "New item";
    public Sprite icon = null;
    public bool isDefaultItem = false;


}
