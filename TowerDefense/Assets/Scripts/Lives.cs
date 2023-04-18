using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] private int _playerLives;
    public static int currentLives { get; private set; }

    private void Start()
    {
        currentLives = _playerLives;

    }

    public void LoseLives(int value)
    {
        currentLives -= value;
        if(currentLives <= 0) 
        {
            Time.timeScale = 0;
        }
    }
}
