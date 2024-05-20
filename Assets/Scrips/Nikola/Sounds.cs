using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public bool IsGrounded()
    {
        RaycastHit hit;
        float rayLength = 1.0f; // Adjust based on your character's size
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
        PulseSound();
    }

    private void PulseSound()
    {
        var audioSource = GetComponent<AudioSource>();
        if (Input.GetMouseButtonUp(0) && IsGrounded() == true)
        {
            audioSource.Play(0);
        }
    }
}
