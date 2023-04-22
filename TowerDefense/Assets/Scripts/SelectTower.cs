using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectTower : MonoBehaviour
{
    [SerializeField] private GameObject SelectedTower;
    [SerializeField] private GameObject SellButton;
    [SerializeField] private TextMeshProUGUI SellDescription;
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
        
        if (SelectedTower != null)
        {
            towerValue = SelectedTower.GetComponent<Value>();
            SellDescription.text = $"Tower Sells for: {towerValue.TowerValue / 2}";
        }
        
        if (Input.GetMouseButtonDown(0) && !placement.BeingPlaced)//Checks if the mouse button is pressed and the player is currently not building
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Tower"))//If the raycast hits the tower and has the tag "Tower" it will make the current selected tower
            {
                SelectedTower = hit.collider.gameObject;
                SellButton.SetActive(true);
            }
            else if (hit.collider != null && !hit.collider.CompareTag("Button"))//If anything else is selected it will make the selected tower empty.
            {
                SelectedTower = null;
                SellButton.SetActive(false);
            }

        }

    }

    public void SellTower()//Sells tower and gives /2 the value of tower.
    {
        if (SelectedTower != null)
        {
            Destroy(SelectedTower);
            SelectedTower = null;
            gold.AddGold(towerValue.TowerValue / 2);
            SellButton.SetActive(false); 
            
        }
    }

}