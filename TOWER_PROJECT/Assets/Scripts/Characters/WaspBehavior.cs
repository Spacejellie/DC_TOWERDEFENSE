using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspBehavior : HoneyBase
{
    public float speed;
    public float xSpeed;
    public float ySpeed;
    public GameObject thisObject;
    public float xDir = 0f;
    public float yDir = 0f;



    public GameManager manager;

    public float reverseTime;
    public float reverseInterval = 3.0f;

    // Start is called before the first frame update
    private void Start()
    {
        speed = Random.Range(xSpeed, ySpeed);  //randomize spawn speed
        xDir = Random.Range(-1f, 1f); //randomize spawn direction
        yDir = Random.Range(-1f, 1f);// randomize spawn direction

    }

    // Update is called once per frame
    void Update()
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
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

    if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
