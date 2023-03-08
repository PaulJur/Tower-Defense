using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSeeking : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemey")
        {
            Debug.Log("I have hit");
        }
    }

    void Update()
    {
        
    }

 
}
