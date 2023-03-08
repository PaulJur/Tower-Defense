using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum damageType
{
    Sharp,
    Explosion,
}


public class Monster : MonoBehaviour
{
    private GameObject Prefab { get; set; }
    private int Health { get; set; }
    private Dictionary<damageType,int> Resistance { get; set; }
 

    public Monster(GameObject prefab,int health, Dictionary<damageType,int>resistance)
    {
        Prefab = prefab;
        Health = health;
        Resistance = resistance;
    }
    
}


