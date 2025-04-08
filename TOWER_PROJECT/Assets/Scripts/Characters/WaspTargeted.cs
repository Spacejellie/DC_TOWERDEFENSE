using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspTargeted : WaspBehavior
{
     // Start is called before the first frame update
    public GameObject targetTower;
    // Start is called before the first frame update
    void Start()
    {
        targetTower = GameObject.FindWithTag("Tower");
        speed = Random.Range(xSpeed, ySpeed);
    }

    // Update is called once per frame
    void Update()
    {
        manager = FindObjectOfType<GameManager>();
        thisObject.transform.position += VectorToTower() * speed;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Outer")
        {

            Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "Mid")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Tower")
        {
            Destroy(gameObject);
        }
    }
    Vector3 VectorToTower() //function to get the direction to the tower from the current enemy
    {
        Vector3 targetDir;
        targetDir = targetTower.transform.position - transform.position; //subtracting the position of the enemy from the posititon of the tower to get the vector for the direction between them

        targetDir = targetDir.normalized; //normalize sets vector magnitude to 1 to clean it up
        return targetDir;//return the direction vector
    }
}
