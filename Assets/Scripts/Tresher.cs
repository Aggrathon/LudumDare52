using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Tresher : MonoBehaviour
{
    public UnityEvent onHarvest;


    public void Harvest()
    {
        onHarvest.Invoke();
        // TODO: harvest FX
    }



    // [Header("Ground")]
    // public LayerMask groundLayerMask = 1 << 3;
    // public float rotationRange = 0.5f;

    // Vector3 left;
    // Vector3 right;
    // Vector3 mid;

    // private void Start()
    // {
    //     var col = GetComponent<BoxCollider>();
    //     left = col.center + new Vector3(-col.size.x * 0.4f, rotationRange, col.size.z * 0.4f);
    //     right = col.center + new Vector3(col.size.x * 0.4f, rotationRange, col.size.z * 0.4f);
    //     mid = col.center + new Vector3(0f, rotationRange, -col.size.z * 0.4f);
    // }

    // private void FixedUpdate()
    // {
    //     var down = -transform.up;
    //     if (Physics.Raycast(transform.TransformPoint(left), down, out RaycastHit hitLeft, rotationRange * 2, groundLayerMask, QueryTriggerInteraction.Ignore) &&
    //         Physics.Raycast(transform.TransformPoint(right), down, out RaycastHit hitRight, rotationRange * 2, groundLayerMask, QueryTriggerInteraction.Ignore) &&
    //         Physics.Raycast(transform.TransformPoint(mid), down, out RaycastHit hitMid, rotationRange * 2, groundLayerMask, QueryTriggerInteraction.Ignore))
    //     {
    //         var side1 = hitLeft.point - hitMid.point;
    //         var side2 = hitRight.point - hitMid.point;
    //         var perp = Vector3.Cross(side1, side2);
    //         transform.localRotation *= Quaternion.FromToRotation(transform.up, perp);
    //     }
    //     else
    //     {
    //         transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.identity, 360f * Time.deltaTime);
    //     }
    // }

    // private void OnDrawGizmosSelected()
    // {
    //     if (!Application.isPlaying)
    //     {
    //         Start();
    //     }
    //     Gizmos.color = Color.magenta;
    //     Gizmos.DrawLine(transform.TransformPoint(left), transform.TransformPoint(left) - transform.up * (2 * rotationRange));
    //     Gizmos.DrawLine(transform.TransformPoint(right), transform.TransformPoint(right) - transform.up * (2 * rotationRange));
    //     Gizmos.DrawLine(transform.TransformPoint(mid), transform.TransformPoint(mid) - transform.up * (2 * rotationRange));
    // }
}
