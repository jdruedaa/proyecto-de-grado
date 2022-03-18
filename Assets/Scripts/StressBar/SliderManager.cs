using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public float timer;
    public float prevTime;

    void Start()
    {
        sl = slider.GetComponent<Slider>();
        timer = 0;
        prevTime = Time.time;
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
        if(sl.value >= 100)
        {
            SceneManager.LoadScene("Game Over");
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
