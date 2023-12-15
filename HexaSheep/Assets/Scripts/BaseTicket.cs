using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BaseTicket : MonoBehaviour
{
    private bool isInteracting = false;
    [SerializeField] GameObject characterPrefab;
    [SerializeField] string characterName;
    protected virtual void OnAttachedToHand(Hand hand)
    {
        isInteracting = true;
    }

    protected virtual void OnDetachedFromHand(Hand hand)
    {
        isInteracting = false;

        foreach (var tile in Main.tiles)
        {
            string tileName = tile.Key;
            GameObject tileGO = tile.Value.gameObject;
            if (Vector3.Distance(this.transform.position, tileGO.transform.position) < 0.15)
            {
                string[] pos = tileName.Split(",");
                int tempX = int.Parse(pos[0]);
                int tempY = int.Parse(pos[1]);

                GameObject objOnTile = Main.tilesObjects[tempX.ToString() + ", " + tempY.ToString()];
                if (objOnTile != null)
                {
                    break;
                } else
                {
                    Main.SpawnCharacter(characterPrefab, characterName, false, false, tempX, tempY, "Ally");
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
    }
}
