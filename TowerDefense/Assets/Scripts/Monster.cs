using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private string _name;
    private int _health;
    private int _speed;
   // private int _armor;
 
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
    public int Speed
    {
        get { return _speed; }
        set
        {
            _speed = value;
        }
    }

   // public int Armor
   // {
    //    get { return _armor; }
   // }


    public Monster(string name, int health, int speed)
    {
        Name= name;
        Health = health;
        Speed = speed;
    }
    
}


