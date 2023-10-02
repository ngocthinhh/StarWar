using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMachine : MonoBehaviour
{
    // PAUSE CANVAS
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject optionPause;

    // MENU CANVAS
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject continueButton;

    [SerializeField] private GameObject nextLevel;

    [SerializeField] private int currentScene = 0;

    // ================== STATE MACHINE ===================
    public enum State
    {
        Menu,
        StartGame,
        ContinueGame,
        NextLevel,
        Pause,
        Continue,
        Quit
    }
    public State currentState = State.Menu;
    public void ChangeState(string newStateString)
    {
        switch (currentState)
        {
            case State.Menu:
                
                break;
            case State.StartGame:

                break;
            case State.ContinueGame:

                break;
            case State.NextLevel:

                break;
            case State.Pause:

                break;
            case State.Continue:

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
            case State.StartGame:
                StartGame();
                break;
            case State.ContinueGame:
                ContinueGame();
                break;
            case State.NextLevel:
                NextLevel();
                break;
            case State.Pause:
                Pause();
                break;
            case State.Continue:
                Continue();
                break;
            case State.Quit:
                Quit();
                break;
        }

        currentState = newState;
    }
    //================================================


    public static SceneMachine Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

        optionPause.SetActive(false);
        pauseCanvas.SetActive(false);

        menuCanvas.SetActive(true);

        if (currentScene > 0)
        {
            continueButton.SetActive(true);
        }
    }

    public void OpenNextLevel()
    {
        nextLevel.SetActive(true);
    }

    public void NextLevel()
    {
        currentScene += 1;
        SceneManager.LoadScene(currentScene);
        nextLevel.SetActive(false);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(currentScene);

        Time.timeScale = 1f;

        pauseCanvas.SetActive(true);

        menuCanvas.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

        pauseCanvas.SetActive(true);

        menuCanvas.SetActive(false);

        currentScene = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        optionPause.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        optionPause.SetActive(false);
    }

}
