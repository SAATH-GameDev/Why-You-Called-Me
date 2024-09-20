using System;
using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour, ICollectible
{
    public Light[] lightsToDisable;
    public float lightsDisableDuration = 5f;
    public GameObject darkAreaTrigger; 
    public float DarkAreaTriggerEnableDuration = 5f;

    public MeshRenderer msh;


    private void Start()
    {
        msh.GetComponent<MeshRenderer>();
    }

    public void Collect()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        if (inventory != null)
        {
            inventory.AddItem(this);
           // gameObject.SetActive(false);
             msh.enabled = false;
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
        yield return new WaitForSeconds(lightsDisableDuration);

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
