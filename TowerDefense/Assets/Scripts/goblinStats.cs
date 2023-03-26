using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goblinStats : MonoBehaviour
{

    private Monster Goblin;

    public Slider HealthBar;

    private void Start()
    {
        Goblin = new Monster("Goblin", 100);
    }

    private void Update()
    {
        HealthBar.value = Goblin.Health;
    }

    public void goblinDamage(int damage)
    {
        Goblin.Health -= damage;

    }
    
}
