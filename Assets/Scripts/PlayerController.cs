using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Vehicle))]
public class PlayerController : MonoBehaviour
{

    Vehicle vehicle;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
    }

    public void OnForward(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            vehicle.Forward();
        }
    }

    public void OnReverse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            vehicle.Reverse();
        }
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            vehicle.Left();
        }
        else if (context.canceled)
        {
            vehicle.Right();
        }
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            vehicle.Right();
        }
        else if (context.canceled)
        {
            vehicle.Left();
        }
    }
}
