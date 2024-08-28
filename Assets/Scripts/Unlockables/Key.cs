using UnityEngine;

public class Key : MonoBehaviour, ICollectible
{
    public void Collect()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        if (inventory != null)
        {
            inventory.AddItem(this);
            gameObject.SetActive(false);
        }
    }

    public void TryUnlock(IUnlockables unlockables)
    {
        if (unlockables.IsLocked)
        {
            unlockables.Unlock();
        }
        else
        {
            Debug.Log("Alredy Unlocked");
        }
    }
}
