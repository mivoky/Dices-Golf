using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecutorCamera : MonoBehaviour
{
    public Transform Object;

    private bool _inObject = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_inObject == false)
        {
            transform.LookAt(Object.position, Vector3.forward);
        }
    }
}
