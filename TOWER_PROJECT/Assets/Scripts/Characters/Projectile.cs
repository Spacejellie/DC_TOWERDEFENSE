using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Tower
{
    public float speed = 1f;
    public Vector3 dir;
    private float lifeTime;
    public float endTime = 3f;

    void Update()
    {
        transform.position += dir * speed;
        lifeTime += Time.deltaTime;
        if (lifeTime >= endTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // or reduce health if using HP system
            Destroy(gameObject);
        }
    }
}
