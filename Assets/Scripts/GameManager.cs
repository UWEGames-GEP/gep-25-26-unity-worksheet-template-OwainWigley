using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { GAMEPLAY, PAUSE }
    public GameState state;
    public bool stateChanged = false;
    public GameObject InventoryUI;
    public int promptsActive = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    public void OnPause() 
    {
        if (state == GameState.GAMEPLAY)
        {
            stateChanged = true;
            state = GameState.PAUSE;
            InventoryUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else if (state == GameState.PAUSE)
        {
            stateChanged = true;
            state = GameState.GAMEPLAY;
            InventoryUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (stateChanged)
        {
            stateChanged = false;

            if (state == GameState.GAMEPLAY) 
            {
                Time.timeScale = 1.0f;
            }
            else if (state == GameState.PAUSE) 
            {
                Time.timeScale = 0.0f;
            }
        }
    }
}
