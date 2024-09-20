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
    public float claustrophobiaDuration = 8.0f;
    private float claustrophobiaTimer;
    private bool inDarkArea;

    public void StartClaustrophobia()
    {
        Debug.Log("Claustrophobia started");
        heartbeatAudio.Play();
        breathingAudio.Play();
        warningMessage.enabled = true;
        inDarkArea = true;
        claustrophobiaTimer = claustrophobiaDuration;
    }

    public void UpdateClaustrophobia(float intensity)
    {
        Debug.Log($"Updating Claustrophobia: Intensity {intensity}, Timer: {claustrophobiaTimer}");
        var color = screenVignette.color;
        color.a = Mathf.Lerp(0, maxVignetteIntensity, intensity);
        screenVignette.color = color;

        heartbeatAudio.pitch = Mathf.Lerp(1.0f, maxHeartbeatPitch, intensity);
        breathingAudio.pitch = Mathf.Lerp(1.0f, maxBreathingPitch, intensity);

        warningMessage.color = new Color(1, 0, 0, intensity);
    }

    public void StopClaustrophobia()
    {
        Debug.Log("Claustrophobia stopped");
        var color = screenVignette.color;
        color.a = 0;
        screenVignette.color = color;

        heartbeatAudio.Stop();
        breathingAudio.Stop();
        warningMessage.enabled = false;
        inDarkArea = false;
    }

    void Update()
    {
        if (inDarkArea)
        {
            Debug.Log($"Claustrophobia Timer Before: {claustrophobiaTimer}");
            claustrophobiaTimer -= Time.deltaTime;

            float intensity = 1 - (claustrophobiaTimer / claustrophobiaDuration);
            UpdateClaustrophobia(intensity);

            Debug.Log($"Claustrophobia Timer After: {claustrophobiaTimer}");

            if (claustrophobiaTimer <= 0)
            {
                Debug.Log("Player should die now");
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
        Debug.Log("Restarting game...");
        yield return new WaitForSeconds(1.0f);
      //  Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        GamePlayCanvasManager.instance.GameOverPanel.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
