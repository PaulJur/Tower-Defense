using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FarmWithCrops : MonoBehaviour
{
    Gold gold;

    [SerializeField] private GameObject emptyFarmPrefab;
    [SerializeField] private GameObject gameManager;

    private bool isHarvastable;
    private void Start()
    {
        isHarvastable= true;
        gameManager = GameObject.Find("GameManager");
        gold = gameManager.gameObject.GetComponent<Gold>();
    }

    private void OnMouseDown()//when the farm is pressed by the player with left click
    {
        

        Quaternion farmRotation = gameObject.transform.rotation;//Get the farm rotation

        if (isHarvastable)
        {
            gold.AddGold(15);//gives gold to the player
            Instantiate(emptyFarmPrefab,gameObject.transform.position, farmRotation);
            Destroy(gameObject);
        }

    }

}
