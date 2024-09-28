using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Door : MonoBehaviour, IUnlockables, IInteractables
{
    public bool isLocked = true;
    private bool isOpened = false;
    private Animator animator;
    public Text uiText;
    private string doorLockedMessage = "Need Key To Unlock";
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
        Inventory inventory = FindObjectOfType<Inventory>();

        if (isLocked)
        {
            if (inventory != null && inventory.HasItem<Key>())
            {
                Unlock();
                ToggleDoor();
            }
            else
            {
                ShowLockedMessage();
            }
        }
        else
        {
            ToggleDoor();
        }
    }

    private void ToggleDoor()
    {
        isOpened = !isOpened;
        if(!animator)
            return;
        animator.Play(isOpened ? "DoorOpen" : "DoorClose");
    }

    private void ShowLockedMessage()
    {
        if (uiText != null)
        {
            uiText.text = doorLockedMessage;
            StartCoroutine(ClearMessageAfterDelay());
        }
    }

    private IEnumerator ClearMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageClearDelay);
        uiText.text = "";
    }

    public void Unlock()
    {
        isLocked = false;
    }

    public bool IsLocked => isLocked;
}
