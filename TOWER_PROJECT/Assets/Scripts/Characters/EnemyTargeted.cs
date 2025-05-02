using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeted : Enemy
{
    public GameObject targetTower;
    public GameObject targetBarrier;

    void Start()
    {
        targetTower = GameObject.FindWithTag("Tower");
    }

    void Update()
    {
        manager = FindObjectOfType<GameManager>();
        thisObject.transform.position += VectorToTower() * speed;
    }

    Vector3 VectorToTower()
    {
        Vector3 targetDir = targetTower.transform.position - transform.position;
        return targetDir.normalized;
    }
}