using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] private LevelEnd _SphereOfEndLevel;

    private void OnTriggerEnter(Collider other)
    {
        {
            var PlayerScript = other.gameObject.GetComponent<AddPulseObject>();
            if (PlayerScript != null)
            {
                _SphereOfEndLevel.DecreaseKeysCount();
                gameObject.GetComponent<KeyBehaviour>().enabled = false;
            }
        }
    }
}
