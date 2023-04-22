using JetBrains.Annotations;
using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    #region variables
    [SerializeField]
    private GameObject[] enemies;//enemy array to spawn.
    [SerializeField]
    private Vector3 spawnLocation;
    private NavMeshAgent agent;
    [SerializeField] private Vector3[] moveLocations;
    [SerializeField]
    private float spawnRadius = 5f;

    private int _currentRound = 0+1;
    private int _currentEnemies;


    private int _enemiesToSpawn = 2;
    private int enemyIncrease;
    [SerializeField] private float _roundTimer;

    [SerializeField] private AudioSource roundCountDownSound;
    

    static public bool roundEnded;
    #endregion


    private StockManager stock;

    public Vector3[] MoveLocations
    {
        get { return moveLocations; }
    }

    public NavMeshAgent Agent
    {
        get; private set;
    }

    public float RoundTimer
    {
        get { return _roundTimer; }
        private set { _roundTimer = value; }

    }
    public int enemiesToSpawn
    {
        get { return _enemiesToSpawn; }
        private set { _enemiesToSpawn = value; }

    }

    public int currentEnemies
    {
        get { return _currentEnemies;}
        set { _currentEnemies = value; }
    }

    public int currentRound
    {
        get { return _currentRound; }
        private set { _currentRound = value; }
    }

    private void Start()
    {
        stock = GetComponent<StockManager>();
        currentEnemies = enemiesToSpawn;
        StartCoroutine(roundSpawn());
        StartCoroutine(stockChangeTimer(1));
    }
    private void Update()
    {
        //If the current enemies are 0 or lower and the round has ended
        //The script adds +1 to currentround, increase the enemy spawn count by the set amount
        //And sets the rest of the levels to 5seconds
        if (currentEnemies <= 0 && roundEnded == true)
        {
            RoundTimer = 10;
            currentRound++;
            enemiesToSpawn += Randomization();
            currentEnemies = enemiesToSpawn;
            
            StartCoroutine(roundSpawn());
            roundEnded = false;

        }
        
         if (RoundTimer > 0) //If round timer is above 0 countdown;
        {
            RoundTimer -= Time.deltaTime;

            if (RoundTimer < 3 && !roundCountDownSound.isPlaying)
            {
                roundCountDownSound.Play();
            }
        }
        else
        {
            RoundTimer = 0;
        }
         

    }
    
    IEnumerator roundSpawn()
    {
        //Creates a sphere on the current Vector3 that allows the enemies to spawn in the radius
        Vector3 randomPos = spawnLocation + Random.insideUnitSphere * spawnRadius;

        yield return new WaitForSeconds(RoundTimer);//waits for round delay amount to spawn enemies

        //Loops trough all the currentEnemies variable
        for (int i = 0; i < currentEnemies; i++)
        {
            int enemyIndex = Random.Range(0, enemies.Length);//randomizes what spawns during the round
         
            GameObject enemy = Instantiate(enemies[enemyIndex], randomPos, Quaternion.identity);//Instaniates current enemyIndex with the prefab array of enemies[] with the position of the Vector 3 randompos

            agent = enemy.GetComponent<NavMeshAgent>();//Gets the enemies navmesh agent component
            agent.SetDestination(moveLocations[0]);//sets the agents destination to the moveLocation set in the inspector.

            
        }
        
    }
    IEnumerator stockChangeTimer(int time)//This is a timer for stocks to change and either decrease or increase in price
    {
        while (true)
        {
            yield return new WaitForSeconds(time);//Waits for a certain period and changes the prices

            stock.GnomeStock.changeStockPrice();
            stock.GafStock.changeStockPrice();
            stock.NahWeGoingUp.changeStockPrice();

            float _gnomePrice = stock.GnomeStock.StockCurrentPrice;
            float _gafStock = stock.GafStock.StockCurrentPrice;
            float _NahWeGoingUp = stock.NahWeGoingUp.StockCurrentPrice;

            yield return new WaitForSeconds(time);

        }
    }

    private int Randomization()
    {
        int value = Random.Range(1, 2);
        return value;
    }

    
}