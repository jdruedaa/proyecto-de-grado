using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderManager : MonoBehaviour
{
    public static SliderManager bar;
    public static float value;
    public GameObject slider;
    Slider sl;
    public Text texto;
    public float timer;
    public float prevTime;

    void Start()
    {
        sl = slider.GetComponent<Slider>();
        timer = 0;
        prevTime = Time.time;
    }
    public void moveSlider(float f)
    {
        value += f;
        if(sl != null){
            sl.value += f;
            texto.text = string.Format("Nivel de estrés {0}/100", Mathf.Floor(sl.value));
        }
        if(sl.value >= 100)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
    void FixedUpdate()
    {
        if(!GameManager.intro){
            moveSlider(0.1f * Time.deltaTime);
        }
        float currentTime = Time.time;
        timer = currentTime - prevTime;
        prevTime = currentTime;
        if(timer >= 900f)
        {
            SceneManager.LoadScene("Congratulations");
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
