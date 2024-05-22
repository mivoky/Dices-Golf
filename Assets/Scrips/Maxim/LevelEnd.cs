using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public int KeysCount = 0;
    [SerializeField] private Material _MaterialReady;

    public void DecreaseKeysCount()
    {
        KeysCount--;
        if (KeysCount <= 0)
        {
            var _MeshRend = GetComponent<MeshRenderer>();
            _MeshRend.material = _MaterialReady;
        }
    }
    //переход на следующий уровень
    private void OnTriggerEnter(Collider other)
    {
        var PlayerScript = other.gameObject.GetComponent<AddPulseObject>();
        if (PlayerScript != null)
        {
            if (KeysCount <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

}
