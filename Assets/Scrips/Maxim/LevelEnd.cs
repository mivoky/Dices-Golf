using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var PlayerScript = collision.gameObject.GetComponent<AddPulseObject>();
        if (PlayerScript != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
