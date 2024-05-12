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

    private GameObject _canvasPause;
    private Pause _pauseCheck;
    private GameObject _player;
    private AddPulseObject _addPulseObject;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
        // обнаружение паузы
        _canvasPause = GameObject.Find("Canvas");
        _pauseCheck = _canvasPause.GetComponent<Pause>();
        // получение информации из компонента AddPulseObject
        _player = GameObject.Find("Dice");
        _addPulseObject = _player.GetComponent<AddPulseObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_pauseCheck.OnPause == false)
        {
            RotateArrow();
        }
    }
    private void RotateArrow()
    {
        transform.position = Player.position;
        if (Input.GetMouseButtonDown(0) && _addPulseObject.IsGrounded() == true)
        {
            mr.enabled = true;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Persecutor.localEulerAngles.y + 90, transform.localEulerAngles.z);
        }
        if (Input.GetMouseButton(0) && _addPulseObject.IsGrounded() == true)
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
