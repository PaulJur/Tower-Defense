using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesTextRotation : MonoBehaviour
{

    private GameObject sceneCamera;
    private Transform textTransform;

    // Start is called before the first frame update
    void Start()
    {
        sceneCamera = GameObject.FindGameObjectWithTag("MainCamera");
        textTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        textTransform.LookAt(textTransform.position + sceneCamera.transform.rotation * Vector3.forward, sceneCamera.transform.rotation * Vector3.up);
    }
}
