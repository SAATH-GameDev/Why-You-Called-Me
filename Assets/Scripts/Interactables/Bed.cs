using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bed : MonoBehaviour, IInteractables
{
    public float sleepDuration = 5.0f;
    public Image blackScreen;

    private bool isSleeping = false;

    public void Interact()
    {
        if (!isSleeping)
        {
            StartSleep();
        }
    }

    private void StartSleep()
    {
        isSleeping = true;
        Debug.Log("Player started sleeping.");

        blackScreen.gameObject.SetActive(true);

        StartCoroutine(SleepRoutine());
    }

    private IEnumerator SleepRoutine()
    {
        yield return StartCoroutine(FadeToBlack());

        yield return new WaitForSeconds(sleepDuration);

        // Fade back in
        yield return StartCoroutine(FadeFromBlack());

        EndSleep();
    }

    private IEnumerator FadeToBlack()
    {
        float fadeDuration = 1.0f;
        Color color = blackScreen.color;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            color.a = Mathf.Lerp(0, 1, t / fadeDuration);
            blackScreen.color = color;
            yield return null;
        }
        color.a = 1;
        blackScreen.color = color;
    }

    private IEnumerator FadeFromBlack()
    {
        float fadeDuration = 1.0f;
        Color color = blackScreen.color;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            color.a = Mathf.Lerp(1, 0, t / fadeDuration);
            blackScreen.color = color;
            yield return null;
        }
        color.a = 0;
        blackScreen.color = color;
    }

    private void EndSleep()
    {
        isSleeping = false;
        Debug.Log("Player woke up.");

        blackScreen.gameObject.SetActive(false);
    }
}
