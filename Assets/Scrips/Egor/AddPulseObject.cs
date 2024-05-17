using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPulseObject : MonoBehaviour
{
    public Transform ToObject;
    public float PowerOfImpuls;
    // Скорость увелечения скалирования
    public float SpeedScale = 1f;
    // Ограничение скалирования
    public float MinScale = 0.5f;
    public float MaxScale = 1.5f;
    // Проверка на паузу
    private GameObject _canvasPause;
    private Pause _pauseCheck;
    // Направление удара и сила удара
    private Vector3 _vectorToObject;
    private Vector3 _vectorFromObject;
    private Rigidbody RB;
    private Vector3 _vectorForce;
    // Скалирование удара
    private float _scalePower = 0;
    private bool _scalePowerUp = true;
    // Проверка на столкновение с землей
    public bool IsGrounded()
    {
        RaycastHit hit;
        float rayLength = 1.9f; // Adjust based on your character's size
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
            StartCoroutine(ForceOfImpact());
            _vectorFromObject = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            _vectorToObject = ToObject.position;
            _vectorForce = _vectorToObject - _vectorFromObject;
            //Debug.Log("LKM");
        }
        if (Input.GetMouseButtonUp(0))
        {
            RB.AddForce(_vectorForce * PowerOfImpuls * _scalePower, ForceMode.Impulse);
            _scalePower = 0;
        }   
    }
    IEnumerator ForceOfImpact()
    {
        Debug.Log(_scalePower);
        if (Input.GetMouseButton(0))
        {
            if (_scalePowerUp)
            {
                _scalePower += SpeedScale * Time.deltaTime;
                if (_scalePower > MaxScale)
                {
                    _scalePowerUp = !_scalePowerUp;
                }
            }
            else
            {
                _scalePower -= Time.deltaTime;
                if (_scalePower < MinScale)
                {
                    _scalePowerUp = !_scalePowerUp;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            yield return null;
        }
    }
}
