using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PersecutorCamera : MonoBehaviour
{
    public Transform Player;
    public float Speed = 5;
    public float MaxDist = 0.1f;
    //private bool _inObject = false;

    private float _dist = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _dist = Vector3.Distance(Player.position, transform.position);
        if (_dist > MaxDist)
        {
            transform.LookAt(Player.position);
            transform.position = Vector3.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }
    }
}
