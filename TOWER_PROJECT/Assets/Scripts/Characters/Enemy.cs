using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : CharacterBase
{
    public float speed;
    public float xSpeed;//for determining random spawn speed
    public float ySpeed;//for deter4mining random spawn speed
    public GameObject thisObject; //for determining random spawn direction
    public float xDir = 0f;//for determining random spawn direction
    public float yDir = 0f;// for determining random spawn direction

    public GameObject enemyProjectile;
    public float fireRate = 2f; // Time between shots
    private float fireCooldown;
    public float bulletSpeed = 5f;
    public int damage = 1;



    public GameManager manager;

    public float reverseTime;
    public float reverseInterval = 3.0f;

    private void Start()
    {
        speed = Random.Range(xSpeed, ySpeed);  //randomize spawn speed
        xDir = Random.Range(-1f, 1f); //randomize spawn direction
        yDir = Random.Range(-1f, 1f);// randomize spawn direction

    }
    private void Update()
    {
        manager = FindObjectOfType<GameManager>();
        thisObject.transform.position += new Vector3(xDir, yDir, 0) * speed; //move in randomized direction
   
        reverseTime += Time.deltaTime;
        if (reverseTime > reverseInterval) //reverse direction when timer runs out
        {
            reverseTime = 0;
            xDir = xDir * -1;
            yDir = yDir * -1;
        }

        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            FireProjectile();
            fireCooldown = fireRate;
        }
    }

    void FireProjectile()
    {
        GameObject target = GameObject.FindWithTag("Tower"); // Make sure your tower is tagged "Tower"
        if (enemyProjectile != null && target != null)
        {
            GameObject bullet = Instantiate(enemyProjectile, transform.position, Quaternion.identity);

            // Calculate direction to target
            Vector2 shootDirection = (target.transform.position - transform.position).normalized;

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = shootDirection * bulletSpeed;
            }

            Destroy(bullet, 5f); 
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
        CharacterBase characterBase = other.GetComponent<CharacterBase>();
        if (characterBase != null)
        {
            characterBase.TakeDamage(damage);
            Destroy(gameObject); // Destroy bullet after hitting
        }
    }


}