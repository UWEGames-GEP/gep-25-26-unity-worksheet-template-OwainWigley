using UnityEngine;

public class ActivateChildObject : MonoBehaviour
{
    public int childIndex;

    // activates child of game object on entering trigger
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")) 
        {
            transform.GetChild(childIndex).gameObject.SetActive(true);
        }
    }

    // deactivates child of game object on entering trigger
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            transform.GetChild(childIndex).gameObject.SetActive(false);
        }
    }
}
