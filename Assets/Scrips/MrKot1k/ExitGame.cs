﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public void Exitgame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
}