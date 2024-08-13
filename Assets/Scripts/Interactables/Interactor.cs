using UnityEngine;

public class Interactor : MonoBehaviour, IInteractables
{
    public Transform InteractorSource;
    public float InteractRange;

    public void Interact()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractables interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}