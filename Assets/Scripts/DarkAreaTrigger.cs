using UnityEngine;

public class DarkAreaTrigger : MonoBehaviour
{
    private PlayerStatus playerStatus;

    void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();  // Make sure this is finding the PlayerStatus script
        if (playerStatus == null)
        {
            Debug.LogError("PlayerStatus script not found!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered dark area"); // Add this line to verify trigger detection
            playerStatus.StartClaustrophobia();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited dark area"); // Add this line to verify trigger detection
            playerStatus.StopClaustrophobia();
        }
    }
}
