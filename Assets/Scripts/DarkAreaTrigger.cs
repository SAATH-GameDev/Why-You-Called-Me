using UnityEngine;

public class DarkAreaTrigger : MonoBehaviour
{
    private PlayerStatus playerStatus;

    void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
        if (playerStatus == null)
        {
            Debug.LogError("PlayerStatus script not found!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered dark area");
            playerStatus.StartClaustrophobia();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited dark area");
            playerStatus.StopClaustrophobia();
        }
    }
}
