using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetOnR : MonoBehaviour
{
    private float t = 0.0f;
    [SerializeField] private GameObject ImgObject;
    [SerializeField] private Transform PlayerTrans;
    [SerializeField] private Rigidbody PlayerRigBod;
    [SerializeField] private Transform ResetPoint;
    [SerializeField] private D6 _D6;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            t = 0;
            ImgObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.R))
        {
            t += (1 * Time.deltaTime);
            t = Mathf.Min(t, 2);
            ImgObject.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, t / 2);
            if (t >= 2)
            {
                t = 0;
                StartCoroutine(ResetPos());
            }
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            ImgObject.SetActive(false);
        }
    }
    IEnumerator ResetPos()
    {
        PlayerTrans.position = ResetPoint.position;
        _D6.DestroyEffect();
        PlayerRigBod.isKinematic = true;
        yield return new WaitForSeconds(0.01f);
        PlayerRigBod.isKinematic = false;
    }
}
