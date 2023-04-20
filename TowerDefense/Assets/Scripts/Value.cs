using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value : MonoBehaviour
{
    [SerializeField] private int _towerValue;

    public int TowerValue
    {
        get { return _towerValue; }
        private set { _towerValue = value; }
        
    }

}
