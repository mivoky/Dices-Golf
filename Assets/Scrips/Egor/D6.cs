using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class D6 : MonoBehaviour
{
    /* Ощущения
     как на х** вращения*/
    public GameObject Player;
    //Материал активированного кубика и его PartycleSystem
    public Material ActivityMaterial;
    //Подъем кубика и его кручение
    public float RotationSpeed = 1.0f;
    public float Speed = 3f;
    public float LiftUp;
    // Минимальное и максимальное время эффектов
    public int MinTime = 10;
    public int MaxTime = 30;
    // Диапазоны случайных значений
    public int MinPowerOfImpuls = 3;
    public int MaxPowerOfImpuls = 7;
    public int MinMass = 1;
    public int MaxMass = 3;
    public int MinLocalScale = 1;
    public int MaxLocalScale = 2;
    // Параметры корутин
    private bool _destroyOtherEffect;
    private bool _coroutineTimer;
    // Тест эффектов
    public bool TestEffects;
    // Техническая переменная
    private int _rand;
    private int _cofLocalScale;
    // Переменные для работы скрипта
    private bool _start = false;
    private Vector3 _endPosition;
    // Компоненты 
    private MeshRenderer _meshRenderer;
    private BoxCollider _boxCollider;
    // Компоненты игрока для редактирования
    private Rigidbody _playerRB;
    private AddPulseObject _playerAddPulse;
    private Transform _playerTransform;
    // Изначальные значения параметров игрока
    private float _originalPlayerRB;
    private float _originalPlayerAddPulse;
    private Vector3 _originalPlayerTransform;
    void Start()
    {
        _endPosition = new Vector3(transform.position.x, transform.position.y + LiftUp, transform.position.z);
        // Получение компонентов
        _meshRenderer = GetComponent<MeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
        // Получение компонентов игрока
        _playerRB = Player.GetComponent<Rigidbody>();
        _playerAddPulse = Player.GetComponent<AddPulseObject>();
        _playerTransform = Player.GetComponent<Transform>();
        // Получение стартовых значений игрока
        _originalPlayerAddPulse = _playerAddPulse.PowerOfImpuls;
        _originalPlayerRB = _playerRB.mass;
        _originalPlayerTransform = _playerTransform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {
        _start = true;
    }
    void Update()
    {
        if (_start)
        {
            _meshRenderer.material = ActivityMaterial; 
            transform.position = Vector3.MoveTowards(transform.position, _endPosition, Speed * Time.deltaTime);
            transform.Rotate(Vector3.one * RotationSpeed);
        }
        if (transform.position == _endPosition && _start)
        {
            EffectTable(Random.Range(1, 4));
            _start = false;
        }
        if (TestEffects)
        {
            EffectTable(Random.Range(1, 4));
            TestEffects = false;
        }
    }
    public void EffectTable(int number)
    {
        //Рандомизация свойств эффекта
        _rand = Random.Range(1, 3);
        if (_rand == 1)
            _destroyOtherEffect = true;
        else
            _destroyOtherEffect = false;
        _rand = Random.Range(1, 3);
        if (_rand == 1)
            _coroutineTimer = true;
        else
            _coroutineTimer = false;

        // Использование корутины: (Уничтожить другие эффекты, включить таймер)
        if (number == 1)
            StartCoroutine(PowerOfImpuls(_destroyOtherEffect, _coroutineTimer));
        if (number == 2)
            StartCoroutine(Mass(_destroyOtherEffect, _coroutineTimer));
        if (number == 3)
            StartCoroutine(PlayerLocalScale(_destroyOtherEffect, _coroutineTimer));
        //Дебаг
        Debug.Log("Эффект:" + number + " Уничтожать другие эффекты:" + _destroyOtherEffect + " Таймер:" + _coroutineTimer);
        // Отключение компонентов кубика
        _meshRenderer.enabled = false;
        _boxCollider.enabled = false;
        
    }

    public void DestroyEffect()
    {
        _playerAddPulse.PowerOfImpuls = _originalPlayerAddPulse;
        _playerRB.mass = _originalPlayerRB;
        _playerTransform.localScale = _originalPlayerTransform;
    }

    IEnumerator PowerOfImpuls(bool destroyOtherEffect, bool timer)
    {
        if (destroyOtherEffect)
        {
            DestroyEffect();
        }
        _playerAddPulse.PowerOfImpuls = Random.Range(MinPowerOfImpuls, MaxPowerOfImpuls + 1);
        Debug.Log(_playerAddPulse.PowerOfImpuls);
        if (timer)
        {
            yield return new WaitForSecondsRealtime(Random.Range(MinTime, MaxTime + 1));
            _playerAddPulse.PowerOfImpuls = _originalPlayerAddPulse;
        }
        Destroy(gameObject);
        yield return null;
    }
    IEnumerator Mass(bool destroyOtherEffect, bool timer)
    {
        if (destroyOtherEffect)
        {
            DestroyEffect();
        }
        _playerRB.mass = Random.Range(MinMass, MaxMass + 1);
        if (timer)
        {
            yield return new WaitForSecondsRealtime(Random.Range(MinTime, MaxTime + 1));
            _playerRB.mass = _originalPlayerRB;
        }
        Destroy(gameObject);
        yield return null;
    }
    IEnumerator PlayerLocalScale(bool destroyOtherEffect, bool timer)
    {
        if (destroyOtherEffect)
        {
            DestroyEffect();
        }
        transform.position += Vector3.up * 2;
        _cofLocalScale = Random.Range(MinLocalScale, MaxLocalScale + 1);
        _playerTransform.localScale = Vector3.one * _cofLocalScale * 10;
        if (timer)
        {
            yield return new WaitForSecondsRealtime(Random.Range(MinTime, MaxTime + 1));
            _playerTransform.localScale = _originalPlayerTransform;
        }
        Destroy(gameObject);
        yield return null;
    }
}
