using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goblinStats : MonoBehaviour
{
    public int goblinHealth;

    [SerializeField]
    private int currentHealth;
    public Slider HealthBar;


    private void Update()
    {
        
        HealthBar.value = goblinHealth;
    }

    private void Awake()
    {
        currentHealth = goblinHealth;
    }

    public void goblinDamage(int damage)
    {
        currentHealth -= damage;

    }
    
}
