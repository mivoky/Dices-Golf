using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public int NumberOfMenu = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            Time.timeScale = 0;
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
