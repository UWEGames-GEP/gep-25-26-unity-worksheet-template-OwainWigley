using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class InventoryUIButton : MonoBehaviour
{
    public TMP_Text text;
    public bool slotEmpty = true;
    public GameObject itemInSlot;

    public void SetButton(GameObject item)
    {
        text.text = item.name;
        itemInSlot = item;
        slotEmpty = false;
        gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = item.GetComponent<Items>().inventoryIcon;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ClearButton()
    {
        text.text = "";
        itemInSlot = null;
        slotEmpty = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
