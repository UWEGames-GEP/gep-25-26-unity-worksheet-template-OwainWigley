using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GridInventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> inventoryUIButtons = new List<GameObject>();

    // sets inventory capacity to the number of buttons in the inventory ui
    private void Start()
    {
        inventory.inventoryCapacity = inventoryUIButtons.Count;
    }

    // finds the first empty slot in the inventory ui and adds the item to that slot
    public void AddToUI(GameObject item) 
    {
        for (int i = 0; i < inventoryUIButtons.Count; i++) 
        {
            InventoryUIButton uiButton = inventoryUIButtons[i].GetComponent<InventoryUIButton>();
            if (uiButton.slotEmpty) 
            {
                item.GetComponent<Items>().inventorySlot = i;
                uiButton.SetButton(item);
                break;
            }
        }
    }

    // on inventory ui button press, if the slot contains an item, calls remove item from inventory with the item in that slot as the parameter
    public void OnInventoryUIButton(int i) 
    {
        if (inventoryUIButtons[i].GetComponent<InventoryUIButton>().slotEmpty == false) 
        {
            inventory.RemoveItem(inventoryUIButtons[i].GetComponent<InventoryUIButton>().itemInSlot);
        }
    }
}
