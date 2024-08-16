using UnityEngine;

public class Door : MonoBehaviour, IInteractables
{
    bool isOpened = false;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        isOpened = !isOpened;
        transform.position += transform.up * (isOpened ? 3.0f : -3.0f);
        
        //animator.Play("DoorOpen");
        //animator.speed = isOpened ? 1 : -1;
    }
}
