using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PersecutorCamera : MonoBehaviour
{
    public Transform Player;
    public float Speed = 5;

    //private bool _inObject = false;
    public float _maxDist = 1;
    private float _dist = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.position);
        _dist = Vector3.Distance(Player.position, transform.position);
        if (_dist > _maxDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }
    }
}
