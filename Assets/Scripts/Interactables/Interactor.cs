using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public Transform cameraTransform;
    public float range = 3;
    public float startOffset = 0.25f;
    public Text interactMessage;  

    void Update()
    {
        CheckForInteractable(); 
    }

    void CheckForInteractable()
    {
        Ray r = new Ray(cameraTransform.position + (cameraTransform.forward * startOffset), cameraTransform.forward);
        if (Physics.Raycast(r, out RaycastHit info, range))
        {
            if (info.collider.gameObject.TryGetComponent(out IInteractables obj))
            {
                interactMessage.text = "Press E to interact";
                interactMessage.enabled = true;
            }
            else
            {
                interactMessage.enabled = false;
            }
        }
        else
        {
            interactMessage.enabled = false; 
        }
    }


    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Ray r = new Ray(cameraTransform.position + (cameraTransform.forward * startOffset), cameraTransform.forward);
            if (Physics.Raycast(r, out RaycastHit info, range))
            {
                if (info.collider.gameObject.TryGetComponent(out IInteractables obj))
                {        
                    obj.Interact();
                }
            }
        }
    }
}