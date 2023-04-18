using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class turretTargeting : MonoBehaviour
{
    [SerializeField] private GameObject SFXManager;
    [SerializeField] private SFX sfx;
    

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
    [SerializeField] private float slowSpeed;//THIS IS FOR SLOWING TOWER ONLY DEFAULT SHOULD BE 1
    [SerializeField] private AudioSource shootingEffectSound;

    public GameObject closestEnemy;

    private void Start()
    {
        SFXManager = GameObject.Find("SFXManager");
        sfx = SFXManager.gameObject.GetComponent<SFX>();
    }

    void Update()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, _towerRange);

        float closestDistance = float.MaxValue;

        foreach (Collider collider in colliders)//for every collider that enters this OverlapSphere
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

        if (closestEnemy != null && Vector3.Distance(transform.position, closestEnemy.transform.position) > _towerRange) //A check if the enemy has left the towers sphere, if it did it, the closestenemy becomes null
        {
            closestEnemy = null;
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

                shootingEffectSound.volume = sfx.SFXSlider.value;
                shootingEffectSound.Play();
                

                if(enemyMonster != null)//If !closestenemy deal damage to it
                {
                    enemyMonster.TakeDamage(turretDamage);
                    NavMeshAgent closestEnemyAgent = closestEnemy.GetComponent<NavMeshAgent>();
                    closestEnemyAgent.speed *= slowSpeed;//THIS IS FOR SLOWING TOWER ONLY Default should be 1.
                }

                
            }

        }        
    }
    private void OnDrawGizmos()//Draws the sphere around the tower. The player cannot see this
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _towerRange);
    }

    

}
