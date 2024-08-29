using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractables
{
    public Light controlledLight;
    private bool isOn = false;

    void Start()
    {
        if (controlledLight != null)
        {
            controlledLight.enabled = isOn;  // Ensure the light starts in the correct state
        }
    }

    public void Interact()
    {
        if (controlledLight != null)
        {
            isOn = !isOn;  // Toggle the light state
            controlledLight.enabled = isOn;  // Enable or disable the light
            Debug.Log($"Light turned {(isOn ? "On" : "Off")}");
        }
    }
}
