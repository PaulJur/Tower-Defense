
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.FilePathAttribute;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] TowerBlueprintPrefab;
    [SerializeField]
    private LayerMask towerLayerMask;
    [SerializeField]
    private GameObject[] towerPrefab;
    [SerializeField] private float[] TowerCosts;
    [SerializeField] private AudioSource TowerPlacementSound;


    [SerializeField]
     GameObject TowerInstance;


    private int towerIndex;
    private bool beingPlaced = false;

    public bool BeingPlaced
    {
        get { return beingPlaced; }
    }

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

                if (!Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Unbuildable")))
                { //If the raycast doesn't hit a layer that is called "Unbuildalbe", allows the player to build there.
                    if (Input.GetMouseButtonDown(0))
                    {
                        TowerPlacementSound.Play();
                        Quaternion towerRotation = TowerBlueprintPrefab[towerIndex].transform.rotation;//Gets the rotation of the blueprint prefab which allows the real tower to save it's rotation.

                        Instantiate(towerPrefab[towerIndex], TowerInstance.transform.position, towerRotation);//Instantiates the tower from the index on mouse position of the TowerInstance and gets the rotatin from the prefab.

                        Destroy(TowerInstance);
                        gold.RemoveGold(TowerCosts[towerIndex]); //removes gold from set tower costs for set towers in the inspector;
                        TowerInstance = null;

                        beingPlaced = false;

                    }
                }
            }
            else { Debug.Log("Cannot place here");}

            if (Input.GetMouseButtonDown(1))//Destroys the blueprint instance.
            {
                Destroy(TowerInstance);
                TowerInstance = null;
                beingPlaced = false;

            }
        }

        

    }

    public void TowerToPlace (int index)
    {
        
        towerIndex = index;
        

        if (beingPlaced)//Checks if the player is trying to press the tower button multiple times.
        {
            Debug.Log("You already have a tower selected, press ESC to cancel");
            return;
        }

        if (TowerCosts[towerIndex] > gold.CurrentGoldAmount)//If the tower costs more than what the player has, it cannot be placed.
        {
            Debug.Log("You don't have enough gold!");
        }
        else//Places the tower 
        {
            Quaternion towerRotation = TowerBlueprintPrefab[towerIndex].transform.rotation;//Gets the rotation of the blueprint prefab which allows the real tower to save it's rotation.
            TowerInstance = Instantiate(TowerBlueprintPrefab[towerIndex], Input.mousePosition, towerRotation);//Instantiates the tower from the index on mouse position of the TowerInstance and gets the rotatin from the prefab.



            beingPlaced = true;
        }

       


        
    }
}
