using UnityEngine;

public class Door : MonoBehaviour, IInteractables
{
    [SerializeField] GameObject doorAnimator;
    bool isOpened = false;
    public void Interact()
    {
        isOpened = !isOpened;
        doorAnimator.GetComponent<Animator>().Play("DoorOpen");
        doorAnimator.GetComponent<Animator>().speed = isOpened ? 1 : -1;
        //collider.enabled = !isOpened;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
