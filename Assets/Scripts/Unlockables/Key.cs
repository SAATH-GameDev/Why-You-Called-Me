using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour, ICollectible
{
    public Light[] lightsToDisable;
    public float disableDuration = 5f;
    public GameObject darkAreaTrigger; 
    public float DarkAreaTriggerEnableDuration = 5f; 

    public void Collect()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        if (inventory != null)
        {
            inventory.AddItem(this);
            gameObject.SetActive(false);

            DisableLightsForTime();
            StartCoroutine(EnableDarkAreaTriggerForTime());
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
            Debug.Log("Already Unlocked");
        }
    }

    private void DisableLightsForTime()
    {
        if (lightsToDisable.Length > 0)
        {
            foreach (Light light in lightsToDisable)
            {
                light.enabled = false;
            }

            StartCoroutine(ReEnableLights());
        }
    }

    private IEnumerator ReEnableLights()
    {
        yield return new WaitForSeconds(disableDuration);

        foreach (Light light in lightsToDisable)
        {
            light.enabled = true;
        }
    }

    private IEnumerator EnableDarkAreaTriggerForTime()
    {
        if (darkAreaTrigger != null)
        {
            darkAreaTrigger.SetActive(true);
            yield return new WaitForSeconds(DarkAreaTriggerEnableDuration);
            darkAreaTrigger.SetActive(false);
        }
    }
}
