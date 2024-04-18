using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera MainCamera;
    public Camera SkyCamera;

    private bool _skyCameraBool = false;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera.enabled = true;
        SkyCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCamera();
    }

    private void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _skyCameraBool = !_skyCameraBool;
            Debug.Log(_skyCameraBool);
        }
        MainCamera.enabled = !_skyCameraBool;
        SkyCamera.enabled = _skyCameraBool;
    }
}
