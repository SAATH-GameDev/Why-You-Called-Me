using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public Transform cameraTransform;
    public float range = 3;

    public void Interact(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Ray r = new Ray(cameraTransform.position, cameraTransform.forward);
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