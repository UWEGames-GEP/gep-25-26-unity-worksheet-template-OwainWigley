using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();

    public GameManager gameManager;
    
    public void AddItem(string itemName) 
    {
        items.Add(itemName);
    }
    public void RemoveItem(string itemName)
    {
        items.Remove(itemName);
    }

    void Start()
    {

    }
   
    void Update()
    {
        if (gameManager.state == GameManager.GameState.GAMEPLAY) 
        {
            /*
            if (Input.GetKeyDown(KeyCode.E))
            {
                AddItem("i tem");
                items.Sort();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                AddItem("e tem");
                items.Sort();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                RemoveItem("e tem");
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                RemoveItem("i tem");
            }
            */
        }
    }
}
