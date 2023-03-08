using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class deleteProjectile : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DeleteProjectile());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DeleteProjectile()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
