using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class InventoryUIButton : MonoBehaviour
{
    public TMP_Text text;
    public bool slotEmpty = true;
    public GameObject itemInSlot;

    // sets text and image of button, sets the picked up item to be in inventory slot and sets slot to not empty
    public void SetButton(GameObject item)
    {
        text.text = item.name;
        itemInSlot = item;
        slotEmpty = false;
        gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = item.GetComponent<Items>().inventoryIcon;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    // sets text of button to nothing and deactivates image, sets the inventory slot of button pressed to null and sets slot to empty
    public void ClearButton()
    {
        text.text = "";
        itemInSlot = null;
        slotEmpty = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
