using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinStats : MonoBehaviour
{

    public float goblinHealth = 5f;
    public float currentGoblinHealth;

    private void Start()
    {
        currentGoblinHealth= goblinHealth;
    }

    public void goblinDamage(float damage)
    {
        currentGoblinHealth -= damage;

    }
    
}
