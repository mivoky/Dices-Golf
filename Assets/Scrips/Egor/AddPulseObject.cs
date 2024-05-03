using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPulseObject : MonoBehaviour
{
    public Transform ToObject;
    public float PowerOfImpuls;

    private GameObject _canvasPause;
    private Pause _pauseCheck;
    private Vector3 _vectorToObject;
    private Vector3 _vectorFromObject;
    private Rigidbody RB;
    private Vector3 _vectorForce;

    // Update is called once per frame
    private void Start()
    {
        _canvasPause = GameObject.Find("Canvas");
        RB = GetComponent<Rigidbody>();
        _pauseCheck = _canvasPause.GetComponent<Pause>();
        
    }
    private void Update()
    {
        if (_pauseCheck.OnPause == false)
        {
            AddPulse();
        }
    }

    private void AddPulse()
    {
        if (Input.GetMouseButton(0))
        {
            _vectorFromObject = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            _vectorToObject = ToObject.position;
            _vectorForce = _vectorToObject - _vectorFromObject;
            //Debug.Log("LKM");
        }
        if (Input.GetMouseButtonUp(0))
        {
            RB.AddForce(_vectorForce * PowerOfImpuls, ForceMode.Impulse);
        }   
    }

}
