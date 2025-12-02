using UnityEngine;

public class DisableUponActivation : MonoBehaviour
{
    public float delay;

    void OnEnable()
    {
        Invoke(nameof(DisableGameObject), delay);
    }

    void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}