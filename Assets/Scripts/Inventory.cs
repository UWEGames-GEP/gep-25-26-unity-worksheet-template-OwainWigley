using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Search;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    GameManager gameManager;
    Transform objectsTransform;

    public void AddItem(GameObject itemName) 
    {
        items.Add(itemName);
    }
    public void RemoveItem(GameObject itemName)
    {
        items.Remove(itemName);
    }

    public void RemoveItem() 
    {
        if ((gameManager.state == GameManager.GameState.GAMEPLAY) && (items.Count > 0))
        {
            GameObject item = items[0];

            Vector3 currentPosition = transform.position;
            Vector3 forward = transform.forward;

            Vector3 newPosition = currentPosition + forward;
            newPosition += new Vector3(0, 1, 0);

            Quaternion currentRotation = transform.rotation;
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 180);

            GameObject newItem = Instantiate(item, newPosition, newRotation, objectsTransform);
            newItem.SetActive(true);
            newItem.name = item.name;

            items.Remove(item);
            Destroy(item.gameObject);
        }
    }

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        objectsTransform = GameObject.Find("Objects").transform;
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
