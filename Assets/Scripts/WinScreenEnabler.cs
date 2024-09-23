using UnityEngine;

public class WinScreenEnabler : MonoBehaviour
{
    public GameObject panel;  // Reference to the panel in the Canvas

    void Start()
    {
        // Make sure the panel is disabled at the start
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    // This function is called when another collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the environment trigger area");

            // Enable the panel when the player enters the trigger
            if (panel != null)
            {
                panel.SetActive(true);
            }
        }
    }
}
