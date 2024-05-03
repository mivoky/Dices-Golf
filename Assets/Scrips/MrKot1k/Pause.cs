using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public int NumberOfMenu = 0;

    public bool OnPause = false;
    void Update()
    {
        //Проверка состояния 
        if (Time.timeScale > 0)
        {
            OnPause = false;
        }
        else
        {
            OnPause = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            Time.timeScale = 0;
            OnPause = true;
        }
    }
    // Продолжить игру
    public void ContinueGame()
    {
        Time.timeScale = 1;
    } 
    // Выход в меню
    public void ExitToMenu()
    {
        SceneManager.LoadScene(NumberOfMenu);
    }
}
