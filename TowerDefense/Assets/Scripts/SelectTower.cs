using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectTower : MonoBehaviour
{
    public GameObject SelectedTower;
    [SerializeField] private GameObject SellButton;
    [SerializeField] private AudioSource TowerSoldSound;
    private Value towerValue;
    private Gold gold;
    private TowerPlacement placement;

    private void Start()
    {
        SellButton.SetActive(false);
        gold = GetComponent<Gold>();
        placement= GetComponent<TowerPlacement>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !placement.BeingPlaced)//Checks if the mouse button is pressed and the player is currently not building
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 


            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Tower"))//If the raycast hits the tower and has the tag "Tower" it will make the current selected tower
            {
                SelectedTower = hit.collider.gameObject;
                SellButton.SetActive(true);
            }      
        }

    }

    public void SellTower()//Sells tower and gives /2 the value of tower.
    {
        if (SelectedTower != null)
        {
            towerValue = SelectedTower.GetComponent<Value>();
            gold.AddGold(towerValue.TowerValue / 2);
            SellButton.SetActive(false);
            Destroy(SelectedTower);
            TowerSoldSound.Play();
            SelectedTower = null;
            
        }
        else { Debug.Log("Nothing to sell"); }
    }
}
