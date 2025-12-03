using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Sprite inventoryIcon;
    private Inventory inventory;
    private bool canInteract = false;
    GameManager gameManager;

    public bool CanInteract => canInteract;

    // finds game manager in scene
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // rotates object every frame
    void Update()
    {
        gameObject.transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    // if player enters trigger, increases the number of prompts active by 1, sets inventory to the player's inventory, sets can interact to true allowing player to be able to pick up item
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            gameManager.promptsActive += 1;
            inventory = collider.GetComponent<Inventory>();
            canInteract = true;
        }
    }

    // if player exits trigger, decreases the number of prompts active by 1, sets can interact to false so player is not able to pick up item
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player")) 
        {
            gameManager.promptsActive -= 1;
            canInteract = false;
        }
    }

    // if the player is able to, adds item to list in inventory, deactivates item object in scene, decreases the number of prompts active by 1, sets can interact to false so player is not able to pick up item, adds the item to the inventory ui
    public void pickUpObject()
    {
        if (canInteract)
        {
            inventory.AddItem(gameObject);
            gameObject.SetActive(false);
            gameManager.promptsActive -= 1;
            canInteract = false;
            inventory.inventoryUI.AddToUI(gameObject);
        }
    }
}
