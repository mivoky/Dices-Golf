using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArrowRotate : MonoBehaviour
{
    public Transform Persecutor;
    public Transform Player;
    public float Speed;

    private MeshRenderer mr;
    private float _mouseHorizontal;
    private float _mouseVertical;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position;
        if (Input.GetMouseButtonDown(0))
        {
            mr.enabled = true;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Persecutor.localEulerAngles.y + 90, transform.localEulerAngles.z);
        }
        if (Input.GetMouseButton(0))
        {
            _mouseHorizontal = Input.GetAxis("Mouse X");
            _mouseVertical = Input.GetAxis("Mouse Y");
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + _mouseHorizontal * Speed * Time.deltaTime, transform.localEulerAngles.z + _mouseVertical * Speed * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            mr.enabled = false;
        }
    }
}
