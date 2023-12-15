using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    [SerializeField] GameObject tileManager;
    [SerializeField] GameObject character;

    List<GameObject> tiles = new List<GameObject>();

    int i = 0;
    bool tileListDone = false;

    void getTilesList()
    {
        foreach (Transform child in tileManager.transform)
        {
            tiles.Add(child.gameObject);
        }
    }

    void Update()
    {
        if (!tileListDone)
        {
            getTilesList();
            tileListDone = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (i < tiles.Count)
            {
                character.transform.position = tiles[i].transform.position;
                i++;
            }
        }

    }
}
