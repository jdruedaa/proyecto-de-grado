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
            var go = new GameObject("first");
            DontDestroyOnLoad(go);
            foreach(var root in go.scene.GetRootGameObjects())
            {
                if(root.tag == "Admin")
                {

                }
                else
                {
                    Destroy(root);
                }
            }
        }
    }

    void ChangeSong()
    {
        song.clip = tense;
        song.Play();
    }

    void FixedUpdate()
    {
        if(!GameManager.intro)
        {
            if(GameManager.handSlider)
            {
                moveSlider(0.11f * Time.deltaTime);
            }
            else
            {
                moveSlider(0.5f * Time.deltaTime);
            }
        }
        if(value >= 50f && !active){
            Debug.Log("midway");
            ChangeSong();
            active = true;
        }
        float currentTime = Time.time;
        timer = currentTime - prevTime;
        if(timer >= 600f)
        {
            SceneManager.LoadScene("Congratulations");
            var go = new GameObject("first");
            DontDestroyOnLoad(go);
            foreach(var root in go.scene.GetRootGameObjects())
            {
                if(root.tag == "Admin")
                {

                }
                else
                {
                    Destroy(root);
                }
            }
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
