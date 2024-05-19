using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseSlider : MonoBehaviour
{
    public AddPulseObject AddPulseObject;
    public RectTransform valueRectTransform;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        valueRectTransform.anchorMax = new Vector2(AddPulseObject._scalePower / AddPulseObject.MaxScale , 1);
    }
}
