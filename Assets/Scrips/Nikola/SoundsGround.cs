using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsGround : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundSound();
    }

    private void GroundSound()
    {
        var audioSource = GetComponent<AudioSource>();
        if (IsGrounded() == false)
        {
            audioSource.Play(0);
        }
    }
}
