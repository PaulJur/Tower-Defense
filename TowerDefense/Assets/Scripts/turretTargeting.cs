using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class turretTargeting : MonoBehaviour
{

    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private int _towerRange;
    [SerializeField]
    private float projectileSpeed;
    [SerializeField]
    private float fireRate;
    private float nextFire;
    [SerializeField]
    private int turretDamage;

    public GameObject closestEnemy;
 
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _towerRange);

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
                nextFire = Time.time + fireRate;
                GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);//Creates a projectile at the tower
                Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;//Gets position of currentEnemy Gameobject and goes towards it
                proj.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;//Sets the speed

                Monsters enemyMonster = closestEnemy.GetComponent<Monsters>();//Grab the closestEnemy Monster component

                if(enemyMonster != null)//If !closestenemy deal damage to it
                {
                    enemyMonster.TakeDamage(turretDamage);
                }
            }

        }           
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _towerRange);
    }

    

}
