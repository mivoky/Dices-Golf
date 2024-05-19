using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsD6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play(0);
    }
}
