using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public static SliderManager bar;
    public static float value;
    public AudioSource song;
    public AudioClip passive;
    public AudioClip tense;
    public GameObject slider;
    public bool active;
    Slider sl;
    public Text texto;

    void Start()
    {
        sl = slider.GetComponent<Slider>();
        song.Play();
        active = false;
    }
    public void moveSlider(float f)
    {
        value += f;
        if(sl != null){
            sl.value += f;
            texto.text = string.Format("Nivel de estrés {0}/100", Mathf.Floor(sl.value));
        }
    }

    void ChangeSong()
    {
        song.clip = tense;
        song.Play();
    }

    void FixedUpdate()
    {
        if(!GameManager.intro){
            moveSlider(0.1f * Time.deltaTime);
        }
        if(value >= 10f && !active){
            Debug.Log("midway");
            ChangeSong();
            active = true;
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
