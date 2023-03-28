using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerplacement : MonoBehaviour
{
    RaycastHit hit;
    Vector3 position;
    public GameObject prefab;
    public LayerMask mask;


    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit,Mathf.Infinity,mask)) { 
            transform.position = hit.point;
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            transform.position = hit.point;

        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

