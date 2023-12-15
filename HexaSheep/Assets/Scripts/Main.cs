using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject tileManager;
    public static Dictionary<string, GameObject> tiles = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> tilesObjects = new Dictionary<string, GameObject>();

    public static bool isTilesDone = false;

    [SerializeField] GameObject samuraiPrefab;

    GameObject tempGameObject;
    bool isPosInit;
    public static bool isCharsInit = false;

    int x, y;
    public bool isEnemy;

    public static int numOfMove = 1;
    //int charTextRotation;

    void Start()
    {
        InitTiles();
    }

    void Update()
    {
        if (!isTilesDone)
        {
            InitTiles();
            isTilesDone = true;
        }

        if (!isCharsInit)
        {
            for (int i = 0; i < 6; i++)
            {
                if (i < 3)
                {
                    //SpawnCharacter(samuraiPrefab, "samurai", true, false, 0, 0);
                } else
                {
                    SpawnCharacter(samuraiPrefab, "samurai", true, true, 0, 7, "Enemy");
                }
            }
            isCharsInit = true;
        }
    }

    private void InitTiles()
    {
        foreach (Transform child in tileManager.transform)
        {
            tiles.Add(child.name, child.gameObject);
            tilesObjects.Add(child.name, null);
        }
    }

    public static bool IsTileExists(int tileX, int tileY)
    {
        string tilePos = tileX.ToString() + ", " + tileY.ToString();
        if (tiles.ContainsKey(tilePos))
            return true;
        return false;
    }

    public static void SpawnCharacter(GameObject prefab, string charName, bool isRand, bool isEnemy, int x, int y, string tag)
    {
        bool isPosInit = false;
        int tempX, tempY;
        int charRotation, charTextRotation;

        GameObject tempGameObject = Instantiate(prefab);
        tempGameObject.tag = tag;

        while (!isPosInit)
        {
            if (isRand)
            {
                tempX = Random.Range(0, 5);
                tempY = y;
            }
            else
            {
                tempX = x;
                tempY = y;
            }

            if (isEnemy)
            {
                charRotation = 90;
                //charTextRotation = -90;
            }
            else
            {
                charRotation = -90;
                //charTextRotation = 90;
            }

            if (charName == "samurai")
            {
                tempGameObject.GetComponent<Samurai>().x = tempX;
                tempGameObject.GetComponent<Samurai>().y = tempY;
            }

            if (tilesObjects[tempX.ToString() + ", " + tempY.ToString()] != null)
            {
                continue;
            }
            else if (tilesObjects[tempX.ToString() + ", " + tempY.ToString()] == null)
            {
                tilesObjects[tempX.ToString() + ", " + tempY.ToString()] = tempGameObject;
                tempGameObject.transform.Rotate(0, charRotation, 0);
                //tempGameObject.transform.GetChild(0).transform.Rotate(0, charTextRotation, 0);
                isPosInit = true;
            }
        }
    }
}