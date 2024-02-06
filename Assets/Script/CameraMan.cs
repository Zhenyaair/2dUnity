using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : MonoBehaviour
{

    [SerializeField] private Transform cam;
  

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(cam.position.x, cam.position.y, transform.position.z);
    }
}
