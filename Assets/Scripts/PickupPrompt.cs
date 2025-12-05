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
    private bool startDelay = true;

    void Start()
    {
        // deactivates prompt at game start
        gameObject.SetActive(false);
        // finds player in scene and sets player input
        player = GameObject.FindGameObjectWithTag("Player");
        playerInput = player.GetComponent<PlayerInput>();
        // sets text to game object's text component
        text = GetComponent<TMP_Text>();
        // invokes delay so input system doesn't cause null reference error on start
        Invoke("StartDelay", 0.1f);
    }

    private void OnEnable()
    {
        // sets prompt according to control scheme when object is enabled
        ChangeControlPrompt();
    }

    // sets start delay to false
    void StartDelay() 
    {
        startDelay = false;
    }

    void LateUpdate()
    {
        // rotates object to look at player
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }

    void ChangeControlPrompt() 
    {
        if (startDelay) 
        {
            Invoke("ChangeControlPrompt", 0.1f);
            return;
        }
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
