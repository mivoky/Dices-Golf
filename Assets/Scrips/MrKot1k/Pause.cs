using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            panel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
