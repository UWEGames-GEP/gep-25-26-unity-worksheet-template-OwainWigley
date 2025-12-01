using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Items : MonoBehaviour
{
    private Inventory inventory;
    private bool canInteract = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            inventory = collider.GetComponent<Inventory>();
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player")) 
        {
            canInteract = false;
        }
    }

    public void pickUpObject() 
    {
        if (canInteract)
        {
            inventory.AddItem(gameObject);
            gameObject.SetActive(false);
            canInteract = false;
        }
    }
}
