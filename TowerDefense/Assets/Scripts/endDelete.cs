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
    private Monsters monsters;

    [SerializeField] private TextMeshPro livesText;
    private GameObject GameManager;

    private void Update()
    {
        livesText.text = $"Lives left: {Lives.CurrentLives}";
    }

    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
        spawner = GameManager.GetComponent<Spawner>();
        lives = GameManager.GetComponent<Lives>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            lives.LoseLives(1);
            spawner.currentEnemies--;
            if (spawner.currentEnemies <= 0)
            {
                Spawner.roundEnded= true;
            }
        }

    }
}
