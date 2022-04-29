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
    public Slider sl;
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
            GameManager.end = true;
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
        if(!GameManager.intro && !GameManager.end)
        {
            float t = GameManager.handSlider? 1.5f: 0.5f;
            t = t + (GameManager.relaxed? (GameManager.totalItems*0.16f+(GameManager.phoneStolen?0f:0.45f))*-1f: 0f);
            moveSlider(t * Time.deltaTime);
        }
        if(value >= 50f && !active){
            ChangeSong();
            active = true;
        }
        float currentTime = Time.time;
        timer = currentTime - prevTime;
        if(timer >= 300f)
        {
            GameManager.end = true;
            SceneManager.LoadScene("Results");
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
