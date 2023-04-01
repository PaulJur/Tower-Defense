using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class endDelete : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            Destroy(other.gameObject);
            Debug.Log("You lost a Life!");
            Spawner.currentEnemies--;
            if (Spawner.currentEnemies <= 0)
            {
                Spawner.roundEnded= true;
            }
        }

    }
}
