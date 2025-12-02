using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> inventoryUIButtons = new List<GameObject>();

    private void OnEnable()
    {
        RefreshInventory();
    }

    void RefreshInventory() 
    {
        foreach (GameObject uiButton in inventoryUIButtons) 
        {
            uiButton.SetActive(false);
        }

        for (int i = 0; i < inventory.items.Count; i++) 
        {
            if (i < inventoryUIButtons.Count) 
            {
                InventoryUIButton uiButton = inventoryUIButtons[i].GetComponent<InventoryUIButton>();
                GameObject item = inventory.items[i];

                uiButton.gameObject.SetActive(true);
                uiButton.SetButton(item);
            }
        }
    }
    public void OnInventoryUIButton(int i) 
    {
        inventory.RemoveItem(i);
        RefreshInventory();

    }
}
