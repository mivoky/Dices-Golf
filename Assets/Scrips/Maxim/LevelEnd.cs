using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public int KeysCount = 0;

    public void DecreaseKeysCount()
    {
        KeysCount--;
    }

    //переход на следующий уровень
    private void OnCollisionEnter(Collision collision)
    {
        var PlayerScript = collision.gameObject.GetComponent<AddPulseObject>();
        if (PlayerScript != null)
        {
            if (KeysCount <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
