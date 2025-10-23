using Unity.VisualScripting;
using UnityEngine;

public class Items : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Inventory inventory = collider.GetComponent<Inventory>();
            inventory.AddItem(gameObject.name);
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject);
        }
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
