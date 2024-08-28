using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public Transform cameraTransform;
    public float range = 3;
    public float startOffset = 0.25f;
    public Text interactMessage;
    private Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        CheckForInteractable();
    }

    void CheckForInteractable()
    {
        Ray r = new Ray(cameraTransform.position + (cameraTransform.forward * startOffset), cameraTransform.forward);
        if (Physics.Raycast(r, out RaycastHit info, range))
        {
            if (info.collider.gameObject.TryGetComponent(out ICollectible collectible))
            {
                interactMessage.text = "Press E to pick up";
                interactMessage.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    collectible.Collect();
                }
            }
            else if (info.collider.gameObject.TryGetComponent(out IInteractables interactObj))
            {
                interactMessage.text = "Press E to interact";
                interactMessage.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact();
                }
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
}
