using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public float RotateSpeed = 100.0f;
    [SerializeField] private LevelEnd _levelEnd;
    [SerializeField] private ParticleSystem _particleSystem;

    //поворот ключа
    void Update()
    {
        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
    }

    //сбор ключа
    private void OnTriggerEnter(Collider other)
    {
        {
            var PlayerScript = other.gameObject.GetComponent<AddPulseObject>();
            if (PlayerScript != null)
            {
                _levelEnd.DecreaseKeysCount();
                Destroy(_particleSystem);
                Destroy(gameObject);
            }
        }
    }
}
