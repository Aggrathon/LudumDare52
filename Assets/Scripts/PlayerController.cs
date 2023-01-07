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

    public void OnSteer(InputAction.CallbackContext context)
    {
        vehicle.Steer(context.ReadValue<float>());
    }
}
