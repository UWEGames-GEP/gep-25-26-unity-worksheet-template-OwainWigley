using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int inventoryCapacity = 16;
    public List<GameObject> items = new List<GameObject>();
    public GridInventoryUI inventoryUI;

    GameManager gameManager;
    Transform objectsTransform;

    // adds item to list of items
    public void AddItem(GameObject itemName) 
    {
        items.Add(itemName);
    }

    // removes a specific game object from inventory
    public void RemoveItem(GameObject itemName)
    {
        GameObject item = itemName;

        // instantiates object in scene at player's current position after removing from inventory
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition;
        newPosition += new Vector3(0, 1, 0);

        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 0);

        GameObject newItem = Instantiate(item, newPosition, newRotation, objectsTransform);
        newItem.SetActive(true);
        newItem.name = item.name;

        // removes item from list
        items.Remove(item);

        // clears the inventory ui button which contained the item
        inventoryUI.inventoryUIButtons[item.GetComponent<Items>().inventorySlot].GetComponent<InventoryUIButton>().ClearButton();

        // destroys previous instance of item from scene
        Destroy(item.gameObject);
    }

    // override with no parameters makes the removed item the first item in the list
    public void RemoveItem() 
    {
        if ((gameManager.state == GameManager.GameState.GAMEPLAY) && (items.Count > 0))
        {
            GameObject item = items[0];
            RemoveItem(item);
        }
    }

    // finds game manager and interactable objects in scene
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        objectsTransform = GameObject.Find("Objects").transform;
    }
}