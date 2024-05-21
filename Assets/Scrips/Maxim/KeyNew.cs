using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyNew : MonoBehaviour
{
    public float RotateSpeed = 100.0f;
    [SerializeField] private GameObject _DisableOnCollection;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _AudSource;

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
                _DisableOnCollection.SetActive(false);
                _AudSource.Play();
                Destroy(_particleSystem);
                Destroy(gameObject);
            }
        }
    }
}

