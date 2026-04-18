using System.Collections.Generic;
using UnityEngine;

public class GridInventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> inventoryUIButtons = new List<GameObject>();
    public GameObject initialButtonSelected;
    public GameObject eventSystem;

    // when the inventory ui is enabled, set the button selected to the initialButtonSelected gameobject
    void OnEnable()
    {
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(initialButtonSelected);
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

    // on inventory ui button press, play sound, and if the slot contains an item, calls remove item from inventory with the item in that slot as the parameter
    public void OnInventoryUIButton(int i) 
    {
        gameObject.GetComponent<AudioSource>().Play();
        if (inventoryUIButtons[i].GetComponent<InventoryUIButton>().slotEmpty == false) 
        {
            inventory.RemoveItem(inventoryUIButtons[i].GetComponent<InventoryUIButton>().itemInSlot);
        }
    }
}
