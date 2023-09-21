using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontalInput = 0;
    public float verticalInput = 0;

    [SerializeField] private Joystick joystick;
    private void Update()
    {
        InputForComputer();

        InputForPhone();
    }

    public void InputForComputer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    public void InputForPhone()
    {
        horizontalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;
    }
}
