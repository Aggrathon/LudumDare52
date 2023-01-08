using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Vehicle : MonoBehaviour
{
    Rigidbody rb;

    [Header("Movement")]

    public int forwardGears = 3;
    public int reverseGears = 1;

    public float speed = 1f;
    public float speedChange = 1f;
    public float turning = 45f;
    public float turningChange = 1f;

    public float targetGear { get; protected set; }
    public float targetTurn { get; protected set; }

    public float gear { get; protected set; }
    public float turn { get; protected set; }

    [Header("Ground")]
    public LayerMask groundLayerMask = 1 << 3;
    // public float rotationRange = 0.5f;
    // public float frontAxle = 0.6f;
    // public float frontAxleWidth = 1f;
    // public float rearAxle = -0.5f;
    // public float rearAxleWidth = 0.9f;

    // Vector3 frontLeft;
    // Vector3 frontRight;
    // Vector3 rearLeft;
    // Vector3 rearRight;

    public void Forward()
    {
        targetGear = Mathf.Min(forwardGears, targetGear + 1);
    }

    public void Reverse()
    {
        targetGear = Mathf.Max(-reverseGears, targetGear - 1);
    }

    public void Steer(float amount)
    {
        targetTurn = Mathf.Clamp(amount, -1, 1);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // frontLeft = new Vector3(-frontAxleWidth * 0.5f, rotationRange, frontAxle);
        // frontRight = new Vector3(frontAxleWidth * 0.5f, rotationRange, frontAxle);
        // rearLeft = new Vector3(-rearAxleWidth * 0.5f, rotationRange, rearAxle);
        // rearRight = new Vector3(rearAxleWidth * 0.5f, rotationRange, rearAxle);
        targetGear = 0f;
        targetTurn = 0f;
        turn = 0f;
        gear = 0f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.layer ^ groundLayerMask) != 0)
        {
            // TODO: Game Over
            Debug.LogWarning("Game Over: Vehicle hit object");
        }
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

        var rot = rb.rotation;
        var pos = rb.position;

        // var up = rot * Vector3.up;
        // var down = -up;
        // if (Physics.Raycast(transform.TransformPoint(frontLeft), down, out RaycastHit hitFrontLeft, rotationRange * 2, groundLayerMask, QueryTriggerInteraction.Ignore) &&
        //     Physics.Raycast(transform.TransformPoint(frontRight), down, out RaycastHit hitFrontRight, rotationRange * 2, groundLayerMask, QueryTriggerInteraction.Ignore) &&
        //     Physics.Raycast(transform.TransformPoint(rearLeft), down, out RaycastHit hitRearLeft, rotationRange * 2, groundLayerMask, QueryTriggerInteraction.Ignore) &&
        //     Physics.Raycast(transform.TransformPoint(rearRight), down, out RaycastHit hitRearRight, rotationRange * 2, groundLayerMask, QueryTriggerInteraction.Ignore))
        // {
        //     var normal = hitFrontLeft.normal + hitFrontRight.normal + hitRearLeft.normal + hitRearRight.normal;
        //     // var side1 = hitFrontLeft.point - hitRearLeft.point;
        //     // var side2 = hitFrontRight.point - hitRearLeft.point;
        //     // var normal = Vector3.Cross(side1, side2);
        //     rot *= Quaternion.RotateTowards(Quaternion.identity, Quaternion.FromToRotation(up, normal), 720f * Time.deltaTime);
        //     // var distance = Mathf.Min(raycastLeft.distance, raycastMid.distance, raycastRight.distance);
        //     var distance = Utils.SecondSmallest(hitFrontLeft.distance, hitRearLeft.distance, hitFrontRight.distance, hitRearRight.distance);
        //     pos.y += rotationRange - distance;
        //     // Debug.Log(distance);
        //     // Debug.Log(normal);
        // }

        rot *= Quaternion.AngleAxis(turn * turning * Time.deltaTime * Mathf.Clamp(gear, -1, 1), rot * Vector3.up);
        pos += rot * Vector3.forward * (gear * speed * Time.deltaTime);
        rb.MovePosition(pos);
        rb.MoveRotation(rot);
    }

    // private void OnDrawGizmosSelected()
    // {
    //     if (!Application.isPlaying)
    //     {
    //         Start();
    //     }
    //     Gizmos.color = Color.magenta;
    //     var down = transform.up * (-2 * rotationRange);
    //     Gizmos.DrawLine(transform.TransformPoint(frontLeft), transform.TransformPoint(frontLeft) + down);
    //     Gizmos.DrawLine(transform.TransformPoint(frontRight), transform.TransformPoint(frontRight) + down);
    //     Gizmos.DrawLine(transform.TransformPoint(rearLeft), transform.TransformPoint(rearLeft) + down);
    //     Gizmos.DrawLine(transform.TransformPoint(rearRight), transform.TransformPoint(rearRight) + down);
    // }
}
