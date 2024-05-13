using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    public float Speed = 100f;
    private float currentSpeed = 100; 
    
    public void SetSent(float value)
    {
        currentSpeed = value;
        PlayerPrefs.SetFloat("Sense", currentSpeed);
    }
    private float _mouseMoveVertical;
    private float _mouseMoveHorizontal;
    private float _rotateVertical;
    private float _rotateHorizontal;
    // Start is called before the first frame update
    private void Start()
    {
        currentSpeed = PlayerPrefs.GetFloat("Sense", Speed);
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            _mouseMoveHorizontal = Input.GetAxis("Mouse X");
            _mouseMoveVertical = Input.GetAxis("Mouse Y");
            _rotateVertical = transform.localEulerAngles.x + -_mouseMoveVertical * currentSpeed * Time.deltaTime;
            _rotateHorizontal = transform.localEulerAngles.y + _mouseMoveHorizontal * currentSpeed* Time.deltaTime;
            transform.localEulerAngles = new Vector3(_rotateVertical, _rotateHorizontal, transform.localEulerAngles.z);
            //Debug.Log("Right");
        }
    }
}
