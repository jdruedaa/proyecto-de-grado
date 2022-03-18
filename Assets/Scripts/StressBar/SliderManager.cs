using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public static SliderManager bar;
    public static float value;
    public GameObject slider;
    Slider sl;
    public Text texto;

    void Start()
    {
        sl = slider.GetComponent<Slider>();
    }
    public void moveSlider(float f)
    {
        value += f;
        if(sl != null){
            sl.value += f;
            texto.text = string.Format("Nivel de estrés {0}/100", Mathf.Floor(sl.value));
        }
    }
    void FixedUpdate()
    {
        if(!GameManager.intro){
            moveSlider(0.1f * Time.deltaTime);
        }
    }

    
    void Awake() 
    {
        if(bar == null){
            DontDestroyOnLoad(gameObject);
            bar = this;
            value = 0;
        }else{                      
            bar.texto = this.texto;  
            Destroy(gameObject);
            bar.sl = slider.GetComponent<Slider>();
            bar.sl.value = value;
        }
    }
}
