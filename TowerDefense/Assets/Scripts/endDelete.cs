using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class endDelete : MonoBehaviour
{
    private Lives lives;
    private Spawner spawner;
    [SerializeField] private TextMeshProUGUI livesText;
    private GameObject GameManager;

    private void Update()
    {
        livesText.text = $"Lives left: {Lives.currentLives}";
    }

    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
        spawner = GameManager.gameObject.GetComponent<Spawner>();
        lives = GetComponent<Lives>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            Destroy(other.gameObject);
            Debug.Log("You lost a Life!");
            lives.LoseLives(1);
            spawner.currentEnemies--;
            if (spawner.currentEnemies <= 0)
            {
                Spawner.roundEnded= true;
            }
        }

    }
}
