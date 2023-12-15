using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class Samurai : Entity
{
    public int x;
    public int y;

    private int oldX;
    private int oldY;

    private bool isInteracting = false;

    //[SerializeField] TextMeshPro infoText;

    void Start()
    {

    }

    void Update()
    {
        //infoText.text = $"Samurai\nHP: {hp}\nDMG: {damage}";

        if (Main.isTilesDone & !isInteracting)
            MoveChar();

        if (hp <= 0)
        {
            EntityDie();
        }

    }

    protected virtual void OnAttachedToHand(Hand hand)
    {
        oldX = x;
        oldY = y;
        isInteracting = true;
    }

    protected virtual void OnDetachedFromHand(Hand hand)
    {
        isInteracting = false;
        foreach (var tile in Main.tiles)
        {
            string tileName = tile.Key;
            GameObject tileGO = tile.Value.gameObject;
            if (Vector3.Distance(this.gameObject.transform.position, tileGO.transform.position) < 0.23)// < 0.5
            {
                int oldX = x;
                int oldY = y;
                string[] pos = tileName.Split(",");
                int tempX = int.Parse(pos[0]);
                int tempY = int.Parse(pos[1]);
                if (this.gameObject.CompareTag("Ally") & Main.numOfMove % 2 != 0)
                {
                    if (((Math.Abs(x - tempX)) > 2) || ((Math.Abs(y - tempY)) > 2))
                    {
                        x = oldX;
                        y = oldY;
                        break;
                    }
                    else
                    {
                        var objOnTile = Main.tilesObjects[tempX.ToString() + ", " + tempY.ToString()];
                        this.gameObject.transform.Rotate(0, this.gameObject.transform.rotation.y, 0);
                        if (objOnTile == null)
                        {
                            x = tempX;
                            y = tempY;
                            Main.numOfMove++;
                            break;
                        }
                        else if (objOnTile != null)
                        {
                            Attack_1(tempX, tempY);
                            Main.numOfMove++;
                            break;
                        }
                        else
                        {
                            x = oldX;
                            y = oldY;
                            break;
                        }
                    }
                } else if (this.gameObject.CompareTag("Enemy") & Main.numOfMove % 2 == 0)
                {
                    if (((Math.Abs(x - tempX)) > 2) || ((Math.Abs(y - tempY)) > 2))
                    {
                        x = oldX;
                        y = oldY;
                        break;
                    }
                    else
                    {
                        var objOnTile = Main.tilesObjects[tempX.ToString() + ", " + tempY.ToString()];
                        this.gameObject.transform.Rotate(0, this.gameObject.transform.rotation.y, 0);
                        if (objOnTile == null)
                        {
                            x = tempX;
                            y = tempY;
                            Main.numOfMove++;
                            break;
                        }
                        else if (objOnTile != null)
                        {
                            Attack_1(tempX, tempY);
                            Main.numOfMove++;
                            break;
                        }
                        else
                        {
                            x = oldX;
                            y = oldY;
                            break;
                        }
                    }
                }
                
            } else
            {
                continue;
            }
        }
    }

    public override void Attack_1(int x, int y)
    {
        Main.tilesObjects[x.ToString() + ", " + y.ToString()].gameObject.GetComponent<Samurai>().hp = 0;
    }

    public void MoveChar()
    {
        string tilePos = x.ToString() + ", " + y.ToString();
        if (Main.IsTileExists(x, y))
        {
            this.transform.position = new Vector3(Main.tiles[tilePos].transform.position.x,
                Main.tiles[tilePos].transform.position.y + this.transform.GetChild(0).GetComponent<Renderer>().bounds.size.y,
                Main.tiles[tilePos].transform.position.z);
            Main.tilesObjects[x.ToString() + ", " + y.ToString()] = this.gameObject;
            Main.tilesObjects[oldX.ToString() + ", " + oldY.ToString()] = null;
        }
    }
}


// at the end on "OnDetachedFromHand" foreach in tilesObject, add new string into list "enemy|ally", if "enemy" then move y = y - 1
// if enemy move to y-1 and tile is not empty, then attack