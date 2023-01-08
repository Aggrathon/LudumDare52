using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CropTile : MonoBehaviour
{
    [Min(1)] public int crops;
    List<Matrix4x4> matrices;
    public Mesh mesh;
    public Material[] mats;
    [Min(0)] public float randomAngle = 5f;
    [Min(0)] public float randomLocation = 0.5f;
    [Min(0)] public float randomHeight = 0.05f;
    public LayerMask groundLayerMask = 1 << 3;

    private void Start()
    {
        matrices = new List<Matrix4x4>();
        for (int i = 0; i < crops; i++)
        {
            var rnd = Random.insideUnitCircle * randomLocation;
            matrices.Add(Matrix4x4.TRS(transform.position + new Vector3(rnd.x, -Random.value * randomHeight, rnd.y), Quaternion.Euler(-90f, 360f * Random.value, randomAngle * Random.value), Vector3.one));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer ^ groundLayerMask) != 0)
        {
            var tresher = other.GetComponent<Tresher>();
            if (tresher != null)
            {
                tresher.Harvest();
                // TODO: Destroy crop FX
            }
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        for (int i = 0; i < mats.Length; i++)
        {
            Graphics.DrawMeshInstanced(mesh, i, mats[i], matrices);
        }
    }
}
