using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyFarm : MonoBehaviour
{
    [SerializeField] private float growTimer=5;
    [SerializeField] private GameObject grownFarm;


    private void Start()
    {
        StartCoroutine(SpawnFarmGrown()); 
    }

    IEnumerator SpawnFarmGrown()
    {
        yield return new WaitForSeconds(growTimer);

        Quaternion farmRotation = gameObject.transform.rotation; // gets the rotation of the empty farm so the farm with the crops doesn't spawn rotated by 180

        Destroy(gameObject);//destroys current gameobject
        GameObject grownFarmPrefab = Instantiate(grownFarm, gameObject.transform.position, farmRotation);//spawns the farm with crops

        yield return new WaitForSeconds(growTimer);
    }

}
