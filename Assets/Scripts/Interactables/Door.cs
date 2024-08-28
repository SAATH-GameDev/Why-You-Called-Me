using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Door : MonoBehaviour, IInteractables
{
    public bool isDoorLocked = false;
    bool isOpened = false;
    Animator animator;
    public Text uiText;
    string doorLockedMessage = "Need Key To Unlock";
    public float messageClearDelay = 2.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (uiText != null)
        {
            uiText.text = "";
        }
    }

    public void Interact()
    {
        if (isDoorLocked)
        {
            
            if (uiText != null)
            {
                uiText.text = doorLockedMessage;
                StartCoroutine(ClearMassageAfterDelay());
            }
        }
        else
        {
            isOpened = !isOpened;

            animator.Play("DoorOpen");

            if (uiText != null)
            {
                StartCoroutine(ClearMassageAfterDelay());
            }
        }
    }

    private IEnumerator ClearMassageAfterDelay()
    {
        yield return new WaitForSeconds(messageClearDelay);
        uiText.text = "";
    }
}
