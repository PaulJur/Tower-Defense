using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    
    [SerializeField]
    private GameObject[] enemies;//enemy array to spawn.
    [SerializeField]
    private Vector3 spawnLocation;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Vector3 moveLocation;
    [SerializeField]
    private float spawnRadius = 5f;

    static public int currentRound = 0+1;
    static public int currentEnemies;
    [SerializeField]
    private int enemiesToSpawn = 3;
    private int enemyIncrease = 5;
    static public float roundDelay=10f;

    static public bool roundEnded;


    public GameObject enemy;//prefab

    private void Start()
    {
        currentEnemies = enemiesToSpawn;

        StartCoroutine(roundSpawn());
        
            
    }
    private void Update()
    {
        //If the current enemies are 0 or lower and the round has ended
        //The script adds +1 to currentround, increase the enemy spawn count by the set amount
        //And sets the rest of the levels to 5seconds
        if (currentEnemies <= 0 && roundEnded == true)
        {
            currentRound++;
            enemiesToSpawn += enemyIncrease;
            currentEnemies = enemiesToSpawn;
            roundDelay = 5f;
            StartCoroutine(roundSpawn());
            roundEnded = false;

        }
        Debug.Log(currentEnemies);
    }
    
    IEnumerator roundSpawn()
    {
        //Creates a sphere on the current Vector3 that allows the enemies to spawn in the radius
        Vector3 randomPos = spawnLocation + Random.insideUnitSphere * spawnRadius;

        yield return new WaitForSeconds(roundDelay);//waits for round delay amount to spawn enemies

        //Loops trough all the currentEnemies variable
        for (int i = 0; i < currentEnemies; i++)
        {
            int enemyIndex = Random.Range(0, enemies.Length);//randomizes what spawns during the round
         
            yield return new WaitForSeconds(0.5f);
            enemy = Instantiate(enemies[enemyIndex], randomPos, Quaternion.identity);//Instaniates current enemyIndex with the prefab array of enemies[] with the position of the Vector 3 randompos


            agent = enemy.GetComponent<NavMeshAgent>();
            agent.SetDestination(moveLocation);
        }
           
            
    }

  
}