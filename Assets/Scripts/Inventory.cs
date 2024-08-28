using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ICollectible> items = new List<ICollectible>();
    public void AddItem(ICollectible item)
    {
        items.Add(item);
        Debug.Log($"{item.GetType().Name}added to inventory!");
    }

    public bool HasItem<T>() where T : ICollectible
    {
            return items.Exists(item => item is T);
    }

}
