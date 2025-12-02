using System.Collections.Generic;
using UnityEngine;

public class GridInventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> inventoryUIButtons = new List<GameObject>();

    private void Start()
    {
        inventory.inventoryCapacity = inventoryUIButtons.Count;
    }

    public void AddToUI(GameObject item) 
    {
        for (int i = 0; i < inventoryUIButtons.Count; i++) 
        {
            InventoryUIButton uiButton = inventoryUIButtons[i].GetComponent<InventoryUIButton>();
            if (uiButton.slotEmpty) 
            {
                uiButton.SetButton(item);
                break;
            }
        }
    }

    public void OnInventoryUIButton(int i) 
    {
        if (inventoryUIButtons[i].GetComponent<InventoryUIButton>().slotEmpty == false) 
        {
            Debug.Log("Removing " + inventoryUIButtons[i].GetComponent<InventoryUIButton>().itemInSlot.name + " from inventory.");
            inventory.RemoveItem(inventoryUIButtons[i].GetComponent<InventoryUIButton>().itemInSlot);
        }
    }
}
