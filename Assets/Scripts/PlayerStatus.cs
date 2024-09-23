using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public Image screenVignette;
    public AudioSource heartbeatAudio;
    public AudioSource breathingAudio;
    public Text warningMessage;
    public float maxVignetteIntensity = 0.5f;
    public float maxHeartbeatPitch = 1.5f;
    public float maxBreathingPitch = 1.5f;
    public float claustrophobiaDuration = 20.0f;
    private float claustrophobiaTimer;
    private bool inDarkArea;
    private bool claustrophobiaActive;

    // Start claustrophobia effect
    public void StartClaustrophobia()
    {
        if (!claustrophobiaActive) // Prevent restarting if already active
        {
            Debug.Log("Claustrophobia started");
            heartbeatAudio.Play();
            breathingAudio.Play();
            warningMessage.enabled = true;
            inDarkArea = true;
            claustrophobiaActive = true;
            claustrophobiaTimer = claustrophobiaDuration;
        }
    }

    // Update claustrophobia effect over time
    public void UpdateClaustrophobia(float intensity)
    {
        var color = screenVignette.color;
        color.a = Mathf.Lerp(0, maxVignetteIntensity, intensity);
        screenVignette.color = color;

        heartbeatAudio.pitch = Mathf.Lerp(1.0f, maxHeartbeatPitch, intensity);
        breathingAudio.pitch = Mathf.Lerp(1.0f, maxBreathingPitch, intensity);

        warningMessage.color = new Color(1, 0, 0, intensity);
    }

    // Stop claustrophobia effect and reset timer
    public void StopClaustrophobia()
    {
        Debug.Log("Claustrophobia stopped");
        inDarkArea = false;
        claustrophobiaActive = false;  // Stop the effect
        claustrophobiaTimer = claustrophobiaDuration; // Reset the timer

        var color = screenVignette.color;
        color.a = 0;
        screenVignette.color = color;

        heartbeatAudio.Stop();
        breathingAudio.Stop();
        warningMessage.enabled = false;

        Debug.Log("Claustrophobia effect fully stopped");
    }

    public bool IsInDarkArea()
    {
        return inDarkArea;
    }

    void Update()
    {
        if (claustrophobiaActive && inDarkArea)
        {
            claustrophobiaTimer -= Time.deltaTime;

            float intensity = 1 - (claustrophobiaTimer / claustrophobiaDuration);
            UpdateClaustrophobia(intensity);

            if (claustrophobiaTimer <= 0 && inDarkArea)
            {
                Debug.Log("Player still in dark area, executing death");
                Die();
            }
        }
    }

    public void Die()
    {
        Debug.Log("Player died due to claustrophobia!");
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1.0f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        GamePlayCanvasManager.instance.GameOverPanel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}