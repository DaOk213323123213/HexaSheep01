using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] public int hp;
    [SerializeField] public int damage;

    //[SerializeField] int x;
    //[SerializeField] int y;

    public virtual void Attack_1(int x, int y) { }
    public virtual void Attack_2() { }
    public virtual void Attack_3() { }

    public void GetDamage(int damage)
    {
        hp -= damage;
    }

    public void EntityDie()
    {
        Destroy(this.gameObject);
    }

    public void MoveForward(GameObject gameObject, int x, int y, int factor)
    {
        if (Main.IsTileExists(x, y + factor))
        {
            string oldTilePos = x.ToString() + ", " + y.ToString();
            string newTilePos = x.ToString() + ", " + (y + factor).ToString();

            gameObject.GetComponent<Samurai>().x = x;
            gameObject.GetComponent<Samurai>().y = y + factor;

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Main.tiles[newTilePos].transform.position, 0.01f);
            Main.tilesObjects[oldTilePos] = null;
            Main.tilesObjects[newTilePos] = gameObject;
        }
    }
    public void MoveBackward(GameObject gameObject, int x, int y, int factor)
    {
        if (Main.IsTileExists(x, y - factor))
        {
            string oldTilePos = x.ToString() + ", " + y.ToString();
            string newTilePos = x.ToString() + ", " + (y - factor).ToString();

            gameObject.GetComponent<Samurai>().x = x;
            gameObject.GetComponent<Samurai>().y = y - factor;

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Main.tiles[newTilePos].transform.position, 0.01f);
            Main.tilesObjects[oldTilePos] = null;
            Main.tilesObjects[newTilePos] = gameObject;
        }
    }
    public void MoveLeft(GameObject gameObject, int x, int y, int factor)
    {
        if (Main.IsTileExists(x - factor, y))
        {
            string oldTilePos = x.ToString() + ", " + y.ToString();
            string newTilePos = (x - factor).ToString() + ", " + y.ToString();

            gameObject.GetComponent<Samurai>().x = x - factor;
            gameObject.GetComponent<Samurai>().y = y;

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Main.tiles[newTilePos].transform.position, 0.01f);
            Main.tilesObjects[oldTilePos] = null;
            Main.tilesObjects[newTilePos] = gameObject;
        }
    }
    public void MoveRight(GameObject gameObject, int x, int y, int factor)
    {
        if (Main.IsTileExists(x + factor, y))
        {
            string oldTilePos = x.ToString() + ", " + y.ToString();
            string newTilePos = (x + factor).ToString() + ", " + y.ToString();

            gameObject.GetComponent<Samurai>().x = x + factor;
            gameObject.GetComponent<Samurai>().y = y;

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Main.tiles[newTilePos].transform.position, 0.01f);
            Main.tilesObjects[oldTilePos] = null;
            Main.tilesObjects[newTilePos] = gameObject;
        }
    }
}
