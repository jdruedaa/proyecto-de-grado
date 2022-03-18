using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public GameObject slider;
    Slider sl;
    public Text texto;

    void Start()
    {
        sl = slider.GetComponent<Slider>();
    }
    public void moveSlider(float f)
    {
        sl.value += f;
        texto.text = string.Format("Nivel de estrés {0}/100", Mathf.Floor(sl.value));
    }
    void FixedUpdate()
    {
        moveSlider(0.5f * Time.deltaTime);
    }
}
