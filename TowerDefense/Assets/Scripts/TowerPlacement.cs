
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
    [SerializeField] private float[] towerCosts;

    [SerializeField]
     GameObject TowerInstance;


    private int towerIndex;
    private bool beingPlaced = false;

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


            if (Physics.Raycast(ray, out hit, Mathf.Infinity, towerLayerMask))
                {
                    TowerInstance.transform.position = hit.point;
                }

           
                if (Input.GetMouseButtonDown(1))
                {
                    
                    Quaternion towerRotation = TowerBlueprintPrefab[towerIndex].transform.rotation;

                    Instantiate(towerPrefab[towerIndex], TowerInstance.transform.position, towerRotation);

                    Destroy(TowerInstance);
                    gold.RemoveGold(towerCosts[towerIndex]); //removes gold from set tower costs for set towers in the inspector;
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

        if (towerCosts[towerIndex] > gold.CurrentGoldAmount)
        {
            Debug.Log("You don't have enough gold!");
        }
        else
        {
            Quaternion towerRotation = TowerBlueprintPrefab[towerIndex].transform.rotation;
            TowerInstance = Instantiate(TowerBlueprintPrefab[towerIndex], Input.mousePosition, towerRotation);
            beingPlaced = true;
        }

       


        
    }
}
