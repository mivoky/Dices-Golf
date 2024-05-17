/*
 *    ______.........--=T=--.........______
      .             |:|
 :-. //           /""""""-.
 ': '-._____..--""(""""""()`---.__
  /:   _..__   ''  ":""""'[] |""`\\
  ': :'     `-.     _:._     '"""" :
   ::          '--=:____:.___....-"
                     O"       O" grp
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTransformWithMouse : MonoBehaviour
{
    // Скорость изменения координаты
    public float Speed;
    // Ограничение изменения
    public float MinCoordinate;
    public float MaxCoordinate;
    // По какой координате изменять
    public bool XCoordinate;
    public bool YCoordinate;
    public bool ZCoordinate;

    // Update is called once per frame
    void Update()
    {
        if (XCoordinate && Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.localPosition += Vector3.right * Speed * Input.GetAxis("Mouse ScrollWheel");
            if (transform.localPosition.x < MinCoordinate)
            {
                transform.localPosition = new Vector3(MinCoordinate, transform.localPosition.y, transform.localPosition.z);
            }
            if (transform.localPosition.x > MaxCoordinate)
            {
                transform.localPosition = new Vector3(MaxCoordinate, transform.localPosition.y, transform.localPosition.z);
            }
        }
        if (YCoordinate && Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.localPosition += Vector3.up * Speed * Input.GetAxis("Mouse ScrollWheel");
            if (transform.localPosition.y < MinCoordinate)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, MinCoordinate, transform.localPosition.z);
            }
            if (transform.localPosition.y > MaxCoordinate)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, MaxCoordinate, transform.localPosition.z);
            }
        }
        if (ZCoordinate && Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.localPosition += Vector3.forward * Speed * Input.GetAxis("Mouse ScrollWheel");
            if (transform.localPosition.z < MinCoordinate)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, MinCoordinate);
            }
            if (transform.localPosition.z > MaxCoordinate)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, MaxCoordinate);
            }
        }

    }
}