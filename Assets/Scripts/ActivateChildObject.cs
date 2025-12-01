using UnityEngine;

public class ActivateChildObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")) 
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
