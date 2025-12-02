using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int inventoryCapacity = 16;
    public List<GameObject> items = new List<GameObject>();
    public GridInventoryUI inventoryUI;

    GameManager gameManager;
    Transform objectsTransform;

    public void AddItem(GameObject itemName) 
    {
        items.Add(itemName);
    }

    public void RemoveItem(GameObject itemName)
    {
        GameObject item = itemName;

        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition;
        newPosition += new Vector3(0, 1, 0);

        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 0);

        GameObject newItem = Instantiate(item, newPosition, newRotation, objectsTransform);
        newItem.SetActive(true);
        newItem.name = item.name;

        items.Remove(item);
        for (int i = 0; i < inventoryUI.inventoryUIButtons.Count; i++)
        {
            InventoryUIButton uiButton = inventoryUI.inventoryUIButtons[i].GetComponent<InventoryUIButton>();
            if (uiButton.itemInSlot == item)
            {
                uiButton.ClearButton();
                //Invoke(nameof(uiButton.ClearButton), 0.1f);
            }
        }
        Destroy(item.gameObject);
    }

    // Q press because call requries parameter so uses the first item in the list
    public void RemoveItem() 
    {
        if ((gameManager.state == GameManager.GameState.GAMEPLAY) && (items.Count > 0))
        {
            GameObject item = items[0];
            RemoveItem(item);
        }
    }

    // remove this function
    // ui button press because call requires parameter so uses the index to remove specific item
    public void RemoveItem(int i) 
    {
        if (i < items.Count) 
        {
            RemoveItem(items[i]);
        }
    }

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        objectsTransform = GameObject.Find("Objects").transform;
    }
}