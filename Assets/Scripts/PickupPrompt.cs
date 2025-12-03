using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupPrompt : MonoBehaviour
{
    private TMP_Text text;
    private PlayerInput playerInput;
    private GameObject player;
    public string gamePadPrompt;
    public string keyboardPrompt;

    void Start()
    {
        // deactivates prompt at game start
        gameObject.SetActive(false);
        // finds player in scene and sets player input
        player = GameObject.FindGameObjectWithTag("Player");
        playerInput = player.GetComponent<PlayerInput>();
        // sets text to game object's text component
        text = GetComponent<TMP_Text>();

        // sets the correct prompt text for keyboard or controller
        if (playerInput.currentControlScheme == "KeyboardMouse") 
        {
            text.text = transform.parent.name + "\n" + keyboardPrompt + " Pick Up";
        }
        else if (playerInput.currentControlScheme == "Gamepad") 
        {
            text.text = transform.parent.name + "\n" + gamePadPrompt + " Pick Up";
        }

    }


    void LateUpdate()
    {
        // rotates object to look at player
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }

    void Update()
    {
        // updates the prompt text if player changes input device
        if (playerInput.currentControlScheme == "KeyboardMouse")
        {
           text.text = transform.parent.name + "\n" + keyboardPrompt + " Pick Up";
        }
        else if (playerInput.currentControlScheme == "Gamepad")
        {
           text.text = transform.parent.name + "\n" + gamePadPrompt + " Pick Up";
        }
    }
}
