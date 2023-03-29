
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] TowerBlueprintPrefab;
    [SerializeField]
    private LayerMask towerLayerMask;
    [SerializeField]
    private GameObject[] towerPrefab;
    

    [SerializeField]
     GameObject TowerInstance;

    private int towerIndex;
    private bool beingPlaced = false;

    public float towerCost;

    Gold gold;

    private void Start()
    {
        gold = GetComponent<Gold>();
    }

    private void Update()
    {
        

        if (TowerInstance !=null && beingPlaced)//if the towerinstance is not null, execute the code below
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           

                if (Physics.Raycast(ray, out hit,Mathf.Infinity,towerLayerMask)) 
            {
                TowerInstance.transform.position = hit.point;
            }

            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(towerPrefab[towerIndex], TowerInstance.transform.position, Quaternion.identity);
                Destroy(TowerInstance);
                gold.RemoveGold(0f);
                TowerInstance = null;
                
                beingPlaced = false;

            }
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(TowerInstance);
            TowerInstance = null;
            beingPlaced = false;
            
        }

    }

    public void TowerToPlace (int index)
    {
        
        towerIndex = index;


        if (beingPlaced)
        {
            Debug.Log("You already have a tower selected, press ESC to cancel");
            return;
        }
        else if(gold.CurrentGoldAmount>=towerCost)
        {
            
            TowerInstance = Instantiate(TowerBlueprintPrefab[towerIndex]);
            beingPlaced = true;
            TowerGoldCost(towerCost);

        }
        else
        {
            Debug.Log("not enough gold");
        }


    }

    public void TowerGoldCost(float amount)
    {
        gold.RemoveGold(amount);
    }
}
