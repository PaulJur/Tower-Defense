using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class turretTargeting : MonoBehaviour
{
    public goblinStats health;

    Spawner spawn;

    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float towerRange;
    [SerializeField]
    private float projectileSpeed;
    [SerializeField]
    private float fireRate;
    private float nextFire;
    [SerializeField]
    private float turretDamage;

    public bool isFired;
    public GameObject closestEnemy;


    private void Start()
    {
        health = health.GetComponent<goblinStats>();
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, towerRange);

        float closestDistance = float.MaxValue;

        foreach (Collider collider in colliders)//for every colllider that enters this OverlapSphere
        {
            GameObject gameObject = collider.gameObject;
            if (gameObject.tag == "Enemy")//if an enemy object with the tag "Enemy" collider enters the sphere
            {
                float distance = Vector3.Distance(transform.position,gameObject.transform.position);//checks the range between current position (tower) to enemy position
                if(distance < closestDistance )
                {
                    closestEnemy = gameObject;
                    closestDistance = distance;
                }
            }
        }
        if (closestEnemy != null)
        {
            if (Time.time > nextFire)
            {
                isFired = true;
                nextFire = Time.time + fireRate;
                GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
                Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
                proj.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;

            }

        }
        if (isFired == true)
        {
            isFired = false;
            health.goblinDamage(5);
            if (health.currentGoblinHealth <= 0)
        {
            Destroy(closestEnemy);
            Spawner.currentEnemies--;
        }
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerRange);
    }

}
