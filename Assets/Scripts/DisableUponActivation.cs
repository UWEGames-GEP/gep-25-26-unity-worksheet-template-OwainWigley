using UnityEngine;

public class DisableUponActivation : MonoBehaviour
{
    public float delay;
    public bool disableOnEnableWithDelay;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        if (disableOnEnableWithDelay) 
        {
            Invoke(nameof(DisableGameObject), delay);
        }

    }

    void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}