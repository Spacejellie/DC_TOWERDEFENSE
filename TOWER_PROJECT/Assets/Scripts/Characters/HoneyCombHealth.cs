using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoneyCombHealth : HoneyBase
{
    public int honeyCombHealth;
    public GameObject honeyCombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        honeyCombHealth = 100; // Set initial health
    }
    // Update is called once per frame
    void Update()
    {
        //OnTriggerEnter2D(Collider2D other)
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Wasp")
        {
            honeyCombHealth -= 10; // Decrease health by 10 when hit by a projectile
            Destroy(other.gameObject);
            if (honeyCombHealth <= 0)
            {
                Destroy(gameObject); // Destroy the honeycomb when health reaches 0
            }
        }
    }
}
