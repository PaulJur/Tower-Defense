using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyFarm : MonoBehaviour
{
    [SerializeField] private float growTimer=5;
    [SerializeField] private GameObject grownFarm;

    private float growingTimer;

    private void Update()
    {
        growingTimer = Time.time;//To count seconds down for the timer

        if (growingTimer >= growTimer)//timer for the farm to execute it's SpawnGrownFarm() code.
        {
            SpawnGrownFarm();
        }

    }

    private void SpawnGrownFarm()
    {
        
            Quaternion farmRotation = gameObject.transform.rotation; // gets the rotation of the empty farm so the farm with the crops doesn't spawn rotated by 180
            Destroy(gameObject);//destroys current gameobject

            GameObject grownFarmPrefab = Instantiate(grownFarm, gameObject.transform.position, farmRotation);//spawns the farm with crops
            growingTimer = 0;
        
        
        
    }

}
