using UnityEngine;
using System.Collections.Generic;

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
        GameObject item = items[0];

        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition;
        newPosition += new Vector3(0, 1, 0);

        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 0);

        GameObject newItem = Instantiate(item, newPosition, newRotation, objectsTransform);
        newItem.SetActive(true);
        newItem.name = item.name;

        items.Remove(item);
        Destroy(item.gameObject);
    }

    public void RemoveItem() 
    {
        if ((gameManager.state == GameManager.GameState.GAMEPLAY) && (items.Count > 0))
        {
            GameObject item = items[0];
            RemoveItem(item);
        }
    }

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
