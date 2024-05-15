using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPulseObject : MonoBehaviour
{
    public Transform ToObject;
    public float PowerOfImpuls;
    // Проверка на паузу
    private GameObject _canvasPause;
    private Pause _pauseCheck;
    // Направление удара и сила удара
    private Vector3 _vectorToObject;
    private Vector3 _vectorFromObject;
    private Rigidbody RB;
    private Vector3 _vectorForce;
    // Проверка на столкновение с землей
    public bool IsGrounded()
    {
        RaycastHit hit;
        float rayLength = 1.1f; // Adjust based on your character's size
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength))
        {
            return true;
        }
        return false;
    }
    // Update is called once per frame
    private void Start()
    {
        //Проверка на паузу
        _canvasPause = GameObject.Find("Canvas");
        _pauseCheck = _canvasPause.GetComponent<Pause>();

        RB = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (_pauseCheck.OnPause == false && IsGrounded() == true)
        {
            AddPulse();
        }
        //Debug.Log(IsGrounded());
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
