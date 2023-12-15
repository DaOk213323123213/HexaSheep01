using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    public int hp;
    public int damage;
    public TextMeshPro entityInfoText;

    public void EntityUpdate()
    {
        CheckHP();
        entityInfoText.text = "HP: " + hp + "\nDMG: " + damage;
    }
    public void CheckHP()
    {
        if (hp <= 0)
        {
            EntityDie();
        }
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
    }

    public void EntityDie()
    {
        Destroy(this.gameObject);
    }
}
