using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileMapGenerator : MonoBehaviour
{
    public GameObject hexTilePrefab;
    [SerializeField] int mapWidth = 25;
    [SerializeField] int mapHeight = 12;

    float tileXOffset = 0.166f; // 1.8f | 0.50f
    float tileZOffset = 0.15f;  // 1.55f | 0.45f

    Vector3 realPos;
    void Start()
    {
        CreateHexTileMap();

    }

    void CreateHexTileMap()
    {
        realPos = this.gameObject.transform.position;
         
        for (int x = 0; x <= mapWidth; x++)
        {
            for (int z = 0; z <= mapHeight; z++)
            {
                GameObject tempGameObject = Instantiate(hexTilePrefab);

                if (z % 2 == 0)
                {
                    tempGameObject.transform.position = new Vector3((realPos.x + x) * tileXOffset, realPos.y, (realPos.z + z) * tileZOffset);
                } else
                {
                    tempGameObject.transform.position = new Vector3((realPos.x + x) * tileXOffset + tileXOffset / 2, realPos.y, (realPos.z + z) * tileZOffset);
                }
                SetTileInfo(tempGameObject, x, z);
            }
        }
    }

    void SetTileInfo(GameObject gameObject, int x, int z)
    {
        gameObject.transform.parent = transform;
        gameObject.name = x.ToString() + ", " + z.ToString();
    }
}
