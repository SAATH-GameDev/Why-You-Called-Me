using UnityEngine;
using System.Collections;

public class DarkAreaTrigger : MonoBehaviour
{
    private PlayerStatus playerStatus;
    public float claustrophobiaDuration = 5f;

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
            StartCoroutine(StopClaustrophobiaAfterTime());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited dark area");
            StopCoroutine(StopClaustrophobiaAfterTime());
            playerStatus.StopClaustrophobia();
        }
    }

    private IEnumerator StopClaustrophobiaAfterTime()
    {
        yield return new WaitForSeconds(claustrophobiaDuration);
        if (playerStatus.IsInDarkArea())
        {
            playerStatus.StopClaustrophobia();
            Debug.Log("Claustrophobia effect stopped after duration");
        }
    }
}
