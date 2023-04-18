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
    #region variables
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

    private int _currentRound = 0+1;
    private int _currentEnemies;


    private int _enemiesToSpawn = 3;
    private int enemyIncrease = 5;
    private float _roundDelay = 10f;

    [SerializeField] private AudioSource roundCountDownSound;
    

    static public bool roundEnded;
    #endregion


    private StockManager stock;


    public float roundDelay
    {
        get { return _roundDelay; }
        private set { _roundDelay = value; }
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
            currentRound++;
            enemiesToSpawn += enemyIncrease;
            currentEnemies = enemiesToSpawn;
            
            StartCoroutine(roundSpawn());
            roundEnded = false;

        }
        
         if (roundDelay > 0) //If round timer is above 0 countdown;
        {
            roundDelay -= Time.deltaTime;

            if (roundDelay < 3 && !roundCountDownSound.isPlaying)
            {
                roundCountDownSound.Play();
            }
        }
        else
        {
            roundDelay = 0;
        }

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
         
            GameObject enemy = Instantiate(enemies[enemyIndex], randomPos, Quaternion.identity);//Instaniates current enemyIndex with the prefab array of enemies[] with the position of the Vector 3 randompos

            agent = enemy.GetComponent<NavMeshAgent>();//Gets the enemies navmesh agent component
            agent.SetDestination(moveLocation);//sets the agents destination to the moveLocation set in the inspector.

            
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


}