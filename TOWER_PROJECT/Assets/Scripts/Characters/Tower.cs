using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : HoneyBase
{
    public float bulletTimer = 0f;
    public float timerReset = 1.0f;
    public GameObject projectile;

    void Update()
    {
        bulletTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W) && bulletTimer >= timerReset)
        {
            GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
            Projectile pScript = proj.GetComponent<Projectile>();
            if (pScript != null)
            {
                pScript.dir = transform.up;
                //the Pscript is the projectile script
                //it sets the direction of the projectile to the direction of the tower
            }

            bulletTimer = 0f;
        }

        Rotation();
    }

    private void Rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with enemy");
            health -= 1;
        }
    }
}