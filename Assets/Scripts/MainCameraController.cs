using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    private Transform fixedCamera;

    private void Start()
    {
       fixedCamera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        fixedCamera.position = new Vector3(transform.position.x, transform.position.y, fixedCamera.position.z);
    }
}
