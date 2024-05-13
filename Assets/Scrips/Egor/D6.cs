using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class D6 : MonoBehaviour
{
    public float Speed = 3f;
    public float LiftUp;
    private bool _start = false;
    private int _effect;
    private Vector3 _endPosition;
    void Start()
    {
        _endPosition = new Vector3(transform.position.x, transform.position.y + LiftUp, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _start = true;
    }
    void Update()
    {
        if (_start)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endPosition, Speed * Time.deltaTime);
        }
        if (transform.position == _endPosition && _start)
        {
            _effect = Random.Range(1, 7);
            Destroy(gameObject);
        }
    }
}
