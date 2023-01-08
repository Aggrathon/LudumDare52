using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureField : MonoBehaviour
{
    public Texture2D texture;
    public Color soilColor;
    public GameObject prefab;

    [Min(0)] public float width = 10f;
    [Min(0)] public float length = 10f;

    [Min(0)] public float widthSpace = 0.2f;
    [Min(0)] public float lengthSpace = 0.2f;

    void Start()
    {
        var widthOffset = (width - Mathf.Floor(width / widthSpace) * widthSpace) * 0.5f;
        var lengthOffset = (length - Mathf.Floor(length / lengthSpace) * lengthSpace) * 0.5f;
        var pos = transform.position - new Vector3(width / 2, 0, length / 2);
        for (float x = widthOffset; x <= width; x += widthSpace)
        {
            int i = Mathf.RoundToInt((1 - x / width) * (float)(texture.width - 1));
            for (float y = lengthOffset; y <= length; y += lengthSpace)
            {
                int j = Mathf.RoundToInt((1 - y / length) * (float)(texture.height - 1));
                if (Utils.SimilarColor(texture.GetPixel(i, j), soilColor, 0.1f))
                    Instantiate(prefab, pos + new Vector3(x, 0, y), Quaternion.identity).transform.SetParent(transform, true);
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
                int i = Mathf.RoundToInt((1 - x / width) * (float)(texture.width - 1));
                for (float y = lengthOffset; y <= length; y += lengthSpace)
                {
                    int j = Mathf.RoundToInt((1 - y / length) * (float)(texture.height - 1));
                    if (Utils.SimilarColor(texture.GetPixel(i, j), soilColor, 0.1f))
                        Gizmos.DrawWireCube(pos + new Vector3(x, 0, y), new Vector3(0.05f, 1f, 0.05f));
                }
            }
        }
    }
}
