using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
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
        if (Input.GetMouseButtonUp(0))
        {
            audioSource.Play(0);
        }
    }
}
