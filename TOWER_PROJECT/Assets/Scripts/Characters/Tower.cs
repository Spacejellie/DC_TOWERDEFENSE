using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : CharacterBase
{
    public float bulletTimer = 0f;
    public float timerReset = 1.0f;
    public GameObject projectile;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        bulletTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.W) && bulletTimer >= timerReset)
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
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collided with enemy");
            health = health - 1;
        }
    }
}