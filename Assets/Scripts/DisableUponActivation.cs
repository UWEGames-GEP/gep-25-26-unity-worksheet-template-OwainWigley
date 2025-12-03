using UnityEngine;

public class DisableUponActivation : MonoBehaviour
{
    public float delay;
    public bool disableOnEnableWithDelay;

    // disables game object on start
    private void Start()
    {
        gameObject.SetActive(false);
    }

    // disables game object after delay when enabled
    void OnEnable()
    {
        if (disableOnEnableWithDelay) 
        {
            Invoke(nameof(DisableGameObject), delay);
        }

    }

    // disables game object
    void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}