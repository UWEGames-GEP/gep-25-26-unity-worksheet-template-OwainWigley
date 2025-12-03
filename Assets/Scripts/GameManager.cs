using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { GAMEPLAY, PAUSE }
    public GameState state;
    public bool stateChanged = false;
    public GameObject InventoryUI;
    public int promptsActive = 0;

    // sets state to gameplay on game start
    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    // if in gameplay, sets the state changed to true for late update, sets state to pause, activates the pause ui, unlocks the cursor for menu navigation
    // if in pause, sets the state changed to true for late update, sets state to gameplay, deactivates the pause ui, locks the cursor
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
