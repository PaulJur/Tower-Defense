using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monsters : MonoBehaviour
{
    [SerializeField]private int _health;
    [SerializeField]private int _goldDrop;
    private int currentHealth;

    [SerializeField] GameObject gameManager;
    [SerializeField] private Slider hpSlider;


    private Gold gold;
    private void Start()
    {
        currentHealth = _health;
        gameManager = GameObject.Find("GameManager");
        gold = gameManager.gameObject.GetComponent<Gold>();

    }

     void Update()
    {
        hpSlider.value = currentHealth;
    }

    public void TakeDamage(int Damage)
    {
        currentHealth-=Damage;
        if(currentHealth<= 0)
        {
            gold.AddGold(_goldDrop);
            Destroy(gameObject);
            Spawner.currentEnemies--;
        
            if (Spawner.currentEnemies <= 0)
            {
                Spawner.roundEnded = true;
            }
        }
    }
}
