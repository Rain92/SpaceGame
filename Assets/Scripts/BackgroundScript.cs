using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField]
    public GameObject tilePrefab;


    List<GameObject> tiles;

    GameObject camera;

    void Start()
    {
        if (tilePrefab.renderer == null)
        {
            Debug.LogError("There is no renderer available to fill background.");
        }

        tiles = new List<GameObject>();

        camera = GameObject.Find("Main Camera");

        // tile size.
        Vector2 tileSize = tilePrefab.renderer.bounds.size;

        // columns and rows.
        int columns = 2;
        int rows = 2;

        // from screen left side to screen right side, because camera is orthographic.
        for (int c = -columns; c < columns; c++)
        {
            for (int r = -rows; r < rows; r++)
            {
                Vector2 position = new Vector2(c * tileSize.x + tileSize.x / 2, r * tileSize.y + tileSize.y / 2);

                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity) as GameObject;
                tile.transform.parent = transform;
                tiles.Add(tile);
            }
        }
        tilePrefab.SetActive(false);
    }
    
    void Update()
    {
        transform.position = new Vector3(camera.transform.position.x - (camera.transform.position.x % tilePrefab.renderer.bounds.size.x), camera.transform.position.y - (camera.transform.position.y % tilePrefab.renderer.bounds.size.y));

    }
}
