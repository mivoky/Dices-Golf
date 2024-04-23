using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera MainCamera;
    public Camera SkyCamera;
    public Transform TransformObject;
    public Transform TransformSkyCamera;

    public float SpeedSkyCamera;
    public float MaxZeroingTimer = 10f;

    private float _moveHorizontal;
    private float _moveVertical;
    private float _zeroingTimer;

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
        ZeroingPosition();
        if (SkyCamera.enabled == true)
        {
            MoveSkyCamera();
        }
    }

    private void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _skyCameraBool = !_skyCameraBool;
        }
        MainCamera.enabled = !_skyCameraBool;
        SkyCamera.enabled = _skyCameraBool;
        //Debug.Log(_skyCameraBool);
    }

    private void MoveSkyCamera()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        _moveVertical = Input.GetAxis("Vertical");
        TransformSkyCamera.position = new Vector3(TransformSkyCamera.position.x + SpeedSkyCamera * _moveHorizontal * Time.deltaTime, TransformSkyCamera.position.y, TransformSkyCamera.position.z + SpeedSkyCamera * _moveVertical * Time.deltaTime);
        //Debug.Log(Input.GetAxis("Horizontal"));
        //Debug.Log(Input.GetAxis("Vertical"));
    }

    private void ZeroingPosition()
    {
        if (SkyCamera.enabled == false)
        {
            _zeroingTimer = _zeroingTimer + Time.deltaTime;
        }
        else
        {
            _zeroingTimer = 0;
        }
        if (Input.GetKeyDown(KeyCode.R) && SkyCamera.enabled == true)
        {
            TransformSkyCamera.position = new Vector3(TransformObject.position.x, TransformSkyCamera.position.y, TransformObject.position.z);
            _zeroingTimer = 0;
        }
        if (_zeroingTimer >= MaxZeroingTimer)
        {
            TransformSkyCamera.position = new Vector3(TransformObject.position.x, TransformSkyCamera.position.y, TransformObject.position.z);
            _zeroingTimer = 0;
        }
    }
}
