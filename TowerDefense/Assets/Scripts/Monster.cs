using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster
{
    private string _name;
    private int _health;
 
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
        }
    }
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
        }
    }
    public Monster(string name, int health)
    {
        Name= name;
        Health = health;
    }
    
}


