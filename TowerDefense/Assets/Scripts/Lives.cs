using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    [SerializeField] private int _playerLives;
    [SerializeField] private GameObject GameOverUI;
    public static int CurrentLives { get; private set; }

    private void Start()
    {
        CurrentLives = _playerLives;

    }


    public void LoseLives(int value)
    {
        CurrentLives -= value;
        if(CurrentLives <= 0) 
        {
            Time.timeScale = 0;
            GameOverUI.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        
    }
}
