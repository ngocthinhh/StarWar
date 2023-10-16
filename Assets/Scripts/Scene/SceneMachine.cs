using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField] private GameObject textEasy;
    [SerializeField] private GameObject textHard;
    [SerializeField] private string modeString;

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

    private void Start()
    {
        SelectEasyMode();
    }

    public void SelectEasyMode()
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.click);

        textEasy.GetComponent<Text>().color = Color.green;
        textHard.GetComponent<Text>().color = Color.white;

        modeString = "Easy";
    }

    public void SelectHardMode()
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.click);

        textEasy.GetComponent<Text>().color = Color.white;
        textHard.GetComponent<Text>().color = Color.green;

        modeString = "Hard";
    }

    public void Menu()
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.click);

        SceneManager.LoadScene(0);
        Time.timeScale = 1;

        optionPause.SetActive(false);
        pauseCanvas.SetActive(false);

        menuCanvas.SetActive(true);

        if (currentScene > 0)
        {
            continueButton.SetActive(true);

            if (currentScene >= 6)
            {
                SelectHardMode();
            }
            else if (currentScene >= 1)
            {
                SelectEasyMode();
            }
        }

        AudioManager.Instance.PlayBackground(AudioManager.Instance.menu);
    }

    public void OpenNextLevel()
    {
        nextLevel.SetActive(true);
    }

    public void NextLevel()
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.click);

        currentScene += 1;
        SceneManager.LoadScene(currentScene);
        nextLevel.SetActive(false);

        if (currentScene == 1 || currentScene == 6)
        {
            AudioManager.Instance.PlayBackground(AudioManager.Instance.level1);
        }
        else if (currentScene == 2 || currentScene == 7)
        {
            AudioManager.Instance.PlayBackground(AudioManager.Instance.level2);
        }
        else if (currentScene == 3 || currentScene == 8)
        {
            AudioManager.Instance.PlayBackground(AudioManager.Instance.level3);
        }
        else if (currentScene == 4 || currentScene == 9)
        {
            AudioManager.Instance.PlayBackground(AudioManager.Instance.level4);
        }
        else if (currentScene == 5 || currentScene == 10)
        {
            AudioManager.Instance.PlayBackground(AudioManager.Instance.level5);
        }
    }

    public void ContinueGame()
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.click);

        SceneManager.LoadScene(currentScene);

        Time.timeScale = 1f;

        pauseCanvas.SetActive(true);

        menuCanvas.SetActive(false);

        if (currentScene == 1 || currentScene == 6)
        {
            AudioManager.Instance.PlayBackground(AudioManager.Instance.level1);
        }
        else if (currentScene == 2 || currentScene == 7)
        {
            AudioManager.Instance.PlayBackground(AudioManager.Instance.level2);
        }
        else if (currentScene == 3 || currentScene == 8)
        {
            AudioManager.Instance.PlayBackground(AudioManager.Instance.level3);
        }
        else if (currentScene == 4 || currentScene == 9)
        {
            AudioManager.Instance.PlayBackground(AudioManager.Instance.level4);
        }
        else if (currentScene == 5 || currentScene == 10)
        {
            AudioManager.Instance.PlayBackground(AudioManager.Instance.level5);
        }
    }

    public void StartGame()
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.click);

        if (modeString.Equals("Easy"))
        {
            SceneManager.LoadScene(1);
            currentScene = 1;
        }
        else if (modeString.Equals("Hard"))
        {
            SceneManager.LoadScene(6);
            currentScene = 6;
        }

        pauseCanvas.SetActive(true);

        menuCanvas.SetActive(false);

        AudioManager.Instance.PlayBackground(AudioManager.Instance.level1);
    }

    public void Quit()
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.click);

        Application.Quit();
    }

    public void Pause()
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.click);

        Time.timeScale = 0;
        optionPause.SetActive(true);

        AudioManager.Instance.Pause();
    }

    public void Continue()
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.click);

        Time.timeScale = 1;
        optionPause.SetActive(false);

        AudioManager.Instance.Continue();
    }

}
