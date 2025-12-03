using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupPrompt : MonoBehaviour
{
    private TMP_Text text;
    private PlayerInput playerInput;
    private GameObject player;

    void Start()
    {
        gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerInput = player.GetComponent<PlayerInput>();
        text = GetComponent<TMP_Text>();

        if (playerInput.currentControlScheme == "KeyboardMouse") 
        {
            text.text = transform.parent.name + "\n" + "[E] Pick Up";
        }
        else if (playerInput.currentControlScheme == "Gamepad") 
        {
            text.text = transform.parent.name + "\n" + "[X] Pick Up";
        }

    }


    void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }

    void Update()
    {
        if (playerInput.currentControlScheme == "KeyboardMouse")
        {
           text.text = transform.parent.name + "\n" + "[E] Pick Up";
        }
        else if (playerInput.currentControlScheme == "Gamepad")
        {
           text.text = transform.parent.name + "\n" + "[X] Pick Up";
        }
    }
}
