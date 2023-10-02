using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToRestart : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        SetOnClick();
    }

    private void SetOnClick()
    {
        button.onClick.AddListener(OutMenu);
    }

    private void OutMenu()
    {
        SceneMachine.Instance.ContinueGame();
    }
}
