using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Sprite inventoryIcon;
    [HideInInspector] public int inventorySlot;
    [Range(0.0f, 1000.0f)] public float rotationSpeed = 50.0f;
    [Range(0.0f, 1.0f)] public float meshScale = 1.0f;
    private Inventory inventory;
    private bool canInteract = false;
    GameManager gameManager;

    public bool CanInteract => canInteract;

    // finds game manager in scene
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        if (transform.localScale == new Vector3(0.75f, 0.75f, 0.75f) * meshScale) return;
        transform.localScale *= meshScale;
        GetComponent<CapsuleCollider>().radius /= meshScale;
        GetComponent<CapsuleCollider>().height /= meshScale;
        GetComponent<BoxCollider>().size /= meshScale;
        transform.GetChild(0).localScale /= meshScale;
        transform.GetChild(0).localPosition /= meshScale;
    }

    // rotates object every frame
    void Update()
    {
        gameObject.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
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
