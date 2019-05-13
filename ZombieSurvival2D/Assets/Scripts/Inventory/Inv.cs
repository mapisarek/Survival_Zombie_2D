using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv : MonoBehaviour
{
    #region Singleton
    public static Inv instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Inventory existing");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Items> items = new List<Items>();
    public int space = 20;

	
	
    public bool Add(Items item)
    {
        Debug.Log("Item added " + item.name);
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);
            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        return true;
    }
	
	    public void Remove(Items item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
