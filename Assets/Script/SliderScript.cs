using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    Slider rotSlider;
    public float nowInput;
    
    // Start is called before the first frame update
    void Awake()
    {
        rotSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetInputSlider()
    {
        nowInput = rotSlider.value;
    }

    public void SetRotSlider(float val)
    {
        rotSlider.value = val;
    }
}
