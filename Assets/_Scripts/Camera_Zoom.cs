using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom : MonoBehaviour
{
    public float minFov;
    public float maxFov;
    private float sensitivity = 10f;

    private float fov;

    // Use this for initialization
    void Start()
    {

    }


    void Update()
    {
        fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
