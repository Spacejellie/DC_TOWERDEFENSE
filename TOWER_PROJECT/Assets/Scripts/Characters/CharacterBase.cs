using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public string characterName;
    public int health = 10;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(characterName + " took " + damage + " damage. Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(characterName + " died!");
        Destroy(gameObject);
    }
}

