using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterBase characterBase = other.GetComponent<CharacterBase>();
        if (characterBase != null)
        {
            characterBase.TakeDamage(damage);
            Destroy(gameObject); // Destroy bullet after hitting
        }
    }
}
