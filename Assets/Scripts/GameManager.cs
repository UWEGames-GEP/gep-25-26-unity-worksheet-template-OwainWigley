using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { GAMEPLAY, PAUSE }
    public GameState state;
    public bool stateChanged = false;
    public GameObject InventoryUI;
    public GameObject OptionsUI;
    public int promptsActive = 0;
    public enum PauseState { OPTIONS, MENU }

    // sets state to gameplay on game start
    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    // if in gameplay, activates the inventory or options ui depending on the pause state, sets the state changed to true for late update, sets state to pause, unlocks the cursor for menu navigation
    // if in pause, deactivates the inventory or options ui depending on the pause state, sets sets the state changed to true for late update, sets state to gameplay, locks the cursor
    public void OnPause(PauseState pauseState)
    {
        if (state == GameState.GAMEPLAY)
        {
            if (pauseState == PauseState.MENU)
            {
                InventoryUI.SetActive(true);
            }
            else 
            {
                OptionsUI.SetActive(true);
            }
            stateChanged = true;
            state = GameState.PAUSE;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (state == GameState.PAUSE)
        {
            if (pauseState == PauseState.MENU)
            {
                InventoryUI.SetActive(false);
            }
            else
            {
                OptionsUI.SetActive(false);
            }
            stateChanged = true;
            state = GameState.GAMEPLAY;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // if in pause, sets the state changed to true for late update, sets state to gameplay, deactivates the options and inventory ui, locks the cursor
    public void OnBack() 
    {
        if (state == GameState.PAUSE) 
        {
            stateChanged = true;
            state = GameState.GAMEPLAY;
            InventoryUI.SetActive(false);
            OptionsUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // if state changed is true, sets it to false then, sets timescale to 1 if in gameplay and 0 if in pause
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
