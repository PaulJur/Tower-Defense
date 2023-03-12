using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healRotation : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneCamera;

    private void Awake()
    {
        sceneCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void LateUpdate()
    {
        transform.LookAt(sceneCamera.transform);
    }
}
