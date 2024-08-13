using UnityEngine;

public class Troch : MonoBehaviour, IInteractables
{
    public Vector3 player ;

    public void Interact()
    {
        Debug.Log("interacted");
        transform.position =  player;
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
