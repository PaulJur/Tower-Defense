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

    public void AddGold(float amount)
    {
        CurrentGoldAmount+= amount;
    }

    public void RemoveGold(float amount)
    { 
        CurrentGoldAmount-= amount;

        if(CurrentGoldAmount < 0)
        {
            CurrentGoldAmount = 0;
        }
    }
}
