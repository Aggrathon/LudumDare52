using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Vehicle : MonoBehaviour
{
    Rigidbody rb;

    public int forwardGears = 3;
    public int reverseGears = 1;

    public float speed = 1f;
    public float speedChange = 1f;
    public float turning = 45f;
    public float turningChange = 1f;

    float targetGear = 0;
    float targetTurn = 0;

    float gear = 0;
    float turn = 0;

    public void Forward()
    {
        targetGear = Mathf.Min(forwardGears, targetGear + 1);
    }

    public void Reverse()
    {
        targetGear = Mathf.Max(-reverseGears, targetGear - 1);
    }

    public void Left()
    {
        targetTurn = Mathf.Max(-1, targetTurn - 1);
    }

    public void Right()
    {
        targetTurn = Mathf.Min(1, targetTurn + 1);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (targetGear != gear)
        {
            gear = Mathf.MoveTowards(gear, targetGear, Time.deltaTime * speedChange);
        }
        if (targetTurn != turn)
        {
            turn = Mathf.MoveTowards(turn, targetTurn, Time.deltaTime * turningChange);
        }

        // var a: Vector3;
        // var b: Vector3;
        // var c: Vector3;
        // var side1: Vector3 = b - a;
        // var side2: Vector3 = c - a;
        // var perp: Vector3 = Vector3.Cross(side1, side2);

        var rot = rb.rotation;
        if (turn != 0 && gear != 0)
        {
            rot *= Quaternion.AngleAxis(turn * turning * Time.deltaTime * Mathf.Min(Mathf.Abs(gear), 1), rot * Vector3.up);
            rb.MoveRotation(rot);
        }
        var forward = rot * Vector3.forward;
        rb.MovePosition(rb.position + forward * (gear * speed * Time.deltaTime));
    }
}
