using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePool : MonoBehaviour
{
    [SerializeField] private TileFactory tileFactory;
    List<TileObject> pooledItems;
    private void Awake()
    {
        pooledItems = new List<TileObject>();
    }

    public TileObject GetTileFromPool()
    {
        if (pooledItems.Count > 0)
        {
            TileObject toReturn = pooledItems[pooledItems.Count - 1];
            pooledItems.RemoveAt(pooledItems.Count - 1);
            return toReturn;
        }
        return tileFactory.GetNewInstance();
    }

    public void ReturnTileToPool(TileObject toReturn)
    {
        toReturn.transform.SetParent(this.transform);
        pooledItems.Add(toReturn);
        toReturn.gameObject.SetActive(false);
    }

    public void ReturnTileToPool(List<TileObject> toReturn)
    {
        foreach(TileObject tileObject in toReturn)
        {
            tileObject.transform.SetParent(this.transform);
            tileObject.gameObject.SetActive(false);
            pooledItems.Add(tileObject);

        }
    }
}
