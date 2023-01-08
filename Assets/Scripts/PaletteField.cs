using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class PaletteField : MonoBehaviour
{
    Tilemap tilemap;
    public Tile cropTile;
    public GameObject prefab;

    public int mult = 10;

    List<Matrix4x4> crops;
    public Mesh mesh;
    public Material[] mats;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        var bounds = tilemap.cellBounds;
        crops = new List<Matrix4x4>();
        foreach (var pos in bounds.allPositionsWithin)
        {
            if (tilemap.GetTile(pos) == cropTile)
            {
                var worldPos = tilemap.CellToWorld(pos);
                for (int i = 0; i < mult; i++)
                {
                    var rnd = Random.insideUnitCircle * (tilemap.cellSize.y * 0.5f) * 0f;
                    // crops.Add(Matrix4x4.TRS(worldPos + new Vector3(rnd.x, Random.value * 0.05f, rnd.y), Quaternion.Euler(-90f, 360f * Random.value, 5f * Random.value), Vector3.one));
                    var g = Instantiate(prefab, worldPos + new Vector3(rnd.x, 0, rnd.y), Quaternion.identity);
                    g.transform.SetParent(transform, true);
                    // gameObject.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        // mesh = prefab.GetComponentInChildren<MeshFilter>().mesh;
        // mats = prefab.GetComponentInChildren<Renderer>().sharedMaterials;
    }

    // private void Update()
    // {
    //     for (int i = 0; i < mats.Length; i++)
    //     {
    //         Graphics.DrawMeshInstanced(mesh, i, mats[i], crops);
    //     }
    // }
}
