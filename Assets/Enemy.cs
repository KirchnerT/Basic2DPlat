using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxHealth = 10;
    public float curHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    public void Hit(float damage)
    {
        if (curHealth <= damage)
        {
            // ADD EXP FOR PLAYER OR DROP ITEMS

            Destroy(this.gameObject);
        }

        // hurt enemey
        curHealth =- damage;

        // knockback enemy
    }

}
