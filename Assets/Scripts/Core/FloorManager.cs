using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] private GameObject floorTile;

    [SerializeField] private Vector2Int gridSize = new Vector2Int(5, 5);

    [SerializeField] private float size = 5;

    Dictionary<int, List<GameObject>> lines = new Dictionary<int, List<GameObject>>();

    private void Start()
    {
        CreateFloor();
    }

    private void CreateFloor()
    {
        Vector2 spawnPos = transform.position;
        float y = transform.position.y;
        float x = transform.position.x;
        List<GameObject> tiles = new List<GameObject>();
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                spawnPos = new Vector2(x, y);
                GameObject tile = Instantiate(floorTile, spawnPos, Quaternion.identity, transform);
                tiles.Add(tile);
                x += size;
            }

            lines.Add(i, tiles);

            tiles.Clear();
            y -= size;
            x = transform.position.x;
        }
    }
}
