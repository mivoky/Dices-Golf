using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject panel;

    public void pause()
    {
        Input.GetKeyDown(KeyCode.Escape);
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
