using System.Collections.Generic;
using StarterAssets;
using UnityEditor;
using UnityEngine;

public class OptionsUI : MonoBehaviour
{
    public List<GameObject> optionsUIButtons = new List<GameObject>();
    public GameObject initialButtonSelected;
    public GameObject eventSystem;
    private GameManager gameManager;
    private GameObject player;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // when the inventory ui is enabled, set the button selected to the initialButtonSelected gameobject
    void OnEnable()
    {
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(initialButtonSelected);
    }

    // on button press, if first button calls OnBack from game manager (resumes game), if second button quits application
    public void OnOptionsUIButton(int i)
    {
        if (i == 0)
        {
            gameManager.OnBack();
            ThirdPersonController controller = player.GetComponent<ThirdPersonController>();
            controller.LockCameraPosition = false;
            controller.menu = false;
            controller.options = false;
        }
        else if (i == 1)
        {
            Application.Quit();
            Debug.Log("Quit Game");
        }
    }
}
