using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Crop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var tresher = other.GetComponent<Tresher>();
        if (tresher)
        {
            tresher.OnHarvest();
            // TODO: Destroy crop
        }
    }
}
