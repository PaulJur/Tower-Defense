using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private float _startingGold = 100;
    private float _currentAmountOfGold;


    void Start()
    {
        _currentAmountOfGold = _startingGold;
    }


    public float CurrentGoldAmount
    {
        get { return _currentAmountOfGold;}
        set
        {
            _currentAmountOfGold = value;
        }
    }

    public void AddGold(float amount)//Adds an amount of gold to the player
    {
        CurrentGoldAmount+= amount;
    }

    public void RemoveGold(float amount)//Removes an amount of gold from the player.
    { 
        CurrentGoldAmount-= amount;

        if(CurrentGoldAmount < 0)
        {
            CurrentGoldAmount = 0;
        }
    }
}
