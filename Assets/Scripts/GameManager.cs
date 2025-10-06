using JetBrains.Annotations;
using System.ComponentModel.Design;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { GAMEPLAY, PAUSE }
    public GameState state;
    public bool stateChanged = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.GAMEPLAY)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                stateChanged = true;
                state = GameState.PAUSE;
            }
        }
        else if (state == GameState.PAUSE)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                stateChanged = true;
                state = GameState.GAMEPLAY;
            }
        }
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
