using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMachine : MonoBehaviour
{
    // ================== STATE MACHINE ===================
    public enum State
    {
        Menu,
        Start,
        Level1,
        Quit
    }
    public State currentState = State.Menu;
    public void ChangeState(string newStateString)
    {
        switch (currentState)
        {
            case State.Menu:

                break;
            case State.Start:

                break;
            case State.Level1:

                break;
            case State.Quit:

                break;
        }

        // CONVERT STRING TO ENUM
        State newState = (State)Enum.Parse(typeof(State), newStateString, true);

        switch (newState)
        {
            case State.Menu:
                Menu();
                break;
            case State.Start:
                
                break;
            case State.Level1:
                StartGame();
                break;
            case State.Quit:
                Quit();
                break;
        }

        currentState = newState;
    }
    //================================================


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
