using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(typeof(SplineContainer))]
public class SplineField : MonoBehaviour
{
    public GameObject prefab;
    [Min(0)] public float widthSpace = 0.2f;
    [Min(0)] public float lengthSpace = 0.2f;
    [Min(0)] public float radius = 2f;

    [SerializeField] bool drawGizmos;

    void Start()
    {
        var spline = GetComponent<SplineContainer>().Spline;
        var bounds = spline.GetBounds();
        var width = bounds.size.x + radius * 2;
        var length = bounds.size.z + radius * 2;
        var widthOffset = (width - Mathf.Floor(width / widthSpace) * widthSpace) * 0.5f;
        var lengthOffset = (length - Mathf.Floor(length / lengthSpace) * lengthSpace) * 0.5f;

        var pos = bounds.center - new Vector3(width / 2, 0, length / 2);
        var nearest = spline.EvaluatePosition(0);
        for (float x = widthOffset; x <= width; x += widthSpace)
        {
            for (float y = lengthOffset; y <= length; y += lengthSpace)
            {
                var np = pos + new Vector3(x, 0, y);
                if (Vector3.Distance(np, nearest) < radius ||
                    SplineUtility.GetNearestPoint(spline, np, out nearest, out _) < radius)
                {
                    Instantiate(prefab, transform.position + np, Quaternion.identity, transform);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
        {
            if (!drawGizmos)
            {
                return;
            }
            Gizmos.color = Color.yellow;
            var spline = GetComponent<SplineContainer>()?.Spline;
            if (spline == null)
                return;
            var bounds = spline.GetBounds();
            var width = bounds.size.x + radius * 2;
            var length = bounds.size.z + radius * 2;
            var widthOffset = (width - Mathf.Floor(width / widthSpace) * widthSpace) * 0.5f;
            var lengthOffset = (length - Mathf.Floor(length / lengthSpace) * lengthSpace) * 0.5f;

            var pos = bounds.center - new Vector3(width / 2, 0.0f, length / 2);
            var nearest = spline.EvaluatePosition(0);
            for (float x = widthOffset; x <= width; x += widthSpace)
            {
                for (float y = lengthOffset; y <= length; y += lengthSpace)
                {
                    var np = pos + new Vector3(x, 0, y);
                    if (Vector3.Distance(np, nearest) < radius ||
                        SplineUtility.GetNearestPoint(spline, np, out nearest, out _) < radius)
                    {
                        np.y -= 0.5f;
                        Gizmos.DrawWireCube(transform.position + np, new Vector3(0.05f, 1f, 0.05f));
                    }
                }
            }
        }
    }
}
