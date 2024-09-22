using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractables
{
    public Light controlledLight;
    private bool isOn = false;

    void Start()
    {
        if (controlledLight != null)
        {
            controlledLight.enabled = isOn;
        }
    }

    public void Interact()
    {
        if (controlledLight != null)
        {
            isOn = !isOn;
            controlledLight.enabled = isOn;
            Debug.Log($"Light turned {(isOn ? "On" : "Off")}");
        }
    }
}
