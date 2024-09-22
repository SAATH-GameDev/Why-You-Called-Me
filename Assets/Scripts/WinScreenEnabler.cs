using UnityEngine;

public class WinScreenEnabler : MonoBehaviour
{
    public GameObject menuPanel;

    void Start()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with the trigger");
            if (menuPanel != null)
            {
                menuPanel.SetActive(true);
            }
        }
    }
}

