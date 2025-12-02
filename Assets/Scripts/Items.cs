using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Sprite inventoryIcon;
    public GridInventoryUI ui;
    //
    private Inventory inventory;
    private bool canInteract = false;
    GameManager gameManager;

    public bool CanInteract => canInteract;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        gameObject.transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            gameManager.promptsActive += 1;
            inventory = collider.GetComponent<Inventory>();
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player")) 
        {
            gameManager.promptsActive -= 1;
            canInteract = false;
        }
    }

    public void pickUpObject()
    {
        if (canInteract)
        {
            inventory.AddItem(gameObject);
            gameObject.SetActive(false);
            gameManager.promptsActive -= 1;
            canInteract = false;
            //
            ui.AddToUI(gameObject);
        }
    }
}
