using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Monsters : MonoBehaviour
{
    private Spawner spawner;
    NavMeshAgent agent;


    [SerializeField]private int _health;
    [SerializeField]private int _goldDrop;
    private int currentHealth;
    private int moveNextIndex;

    [SerializeField] GameObject gameManager;
    [SerializeField] private Slider hpSlider;


    private Gold gold;
    private void Start()
    {
        currentHealth = _health;
        gameManager = GameObject.Find("GameManager");
        gold = gameManager.gameObject.GetComponent<Gold>();
        spawner= gameManager.GetComponent<Spawner>();
        agent = GetComponent<NavMeshAgent>();

    }

     void Update()
    {
        hpSlider.value = currentHealth;

        Vector3 modelDirection = agent.destination - transform.position;//Calculates the difference between current model POS and destination. Gives a vector that points from model to destination
        modelDirection.y = 0;//Makes the modelDirection ignore the Y plane.
        modelDirection = new Vector3(modelDirection.z, modelDirection.y, -modelDirection.x);//Rotates the model by 90 on the X plane so the model looks the right direction
        transform.LookAt(transform.position + modelDirection);//makes the model look at the direction it needs to look at. //Still need to look at this

        if (agent.remainingDistance <= agent.stoppingDistance)//If the agent reaches it's MoveLocation[] array element POS then the MoveToOtherLocation() function gives the next location
        {
            MoveToOtherLocation();
        }
    }

    public void TakeDamage(int Damage)//Function for Monsters taking damage from towers.
    {
        currentHealth-=Damage;
        if(currentHealth<= 0)//If monster health is lower or equal to 0 then the object gets destroyed, gives gold and reduces the current enemy count.
        {
            gold.AddGold(_goldDrop);
            Destroy(gameObject);
            spawner.currentEnemies--;
        
            if (spawner.currentEnemies <= 0)//If current enemy count reaches lower or equal to 0 the round has ended.
            {
                Spawner.roundEnded = true;
            }
        }
    }

    private void MoveToOtherLocation()//Function to make the monster go towards each coordinates in the MoveLocations array.
    {
        agent.SetDestination(spawner.MoveLocations[moveNextIndex]);
        moveNextIndex++;
    }
}
