using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{

    public GameObject prefab;

    [Min(0)] public float width = 10f;
    [Min(0)] public float length = 10f;

    [Min(0)] public float widthSpace = 0.2f;
    [Min(0)] public float lengthSpace = 0.1f;

    void Start()
    {
        var widthOffset = (width - Mathf.Floor(width / widthSpace) * widthSpace) * 0.5f;
        var lengthOffset = (length - Mathf.Floor(length / lengthSpace) * lengthSpace) * 0.5f;
        var pos = transform.position - new Vector3(width / 2, 0, length / 2);
        for (float x = widthOffset; x <= width; x += widthSpace)
        {
            for (float y = lengthOffset; y <= length; y += lengthSpace)
            {
                Instantiate(prefab, pos + new Vector3(x, 0, y), Quaternion.identity, transform);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, 1f, length));
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
        {
            Gizmos.color = Color.yellow;
            var widthOffset = (width - Mathf.Floor(width / widthSpace) * widthSpace) * 0.5f;
            var lengthOffset = (length - Mathf.Floor(length / lengthSpace) * lengthSpace) * 0.5f;
            var pos = transform.position - new Vector3(width / 2, -0.5f, length / 2);
            for (float x = widthOffset; x <= width; x += widthSpace)
            {
                for (float y = lengthOffset; y <= length; y += lengthSpace)
                {
                    Gizmos.DrawWireCube(pos + new Vector3(x, 0, y), new Vector3(0.05f, 1f, 0.05f));
                }
            }
        }
    }
}
