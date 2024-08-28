using UnityEngine;

public class Torch : MonoBehaviour, IInteractables
{
    public GameObject FlashLight;
    public void Interact()
    {
        Destroy(gameObject);
        FlashLight.SetActive(true);
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
