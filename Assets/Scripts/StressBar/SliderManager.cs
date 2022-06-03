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
            GameManager.gameOverReason = "Tu nivel de estrés llegó al máximo y te bajaste del bus antes de tu destino.";
            GameManager.GameOver();
        }
    }

    void ChangeSong()
    {
        song.clip = tense;
        song.Play();
    }

    public void chocolate()
    {
        float t = -15f;
        moveSlider(t * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if(!GameManager.intro && !GameManager.end)
        {
            float t = 0.5f;
            float relaxedMod = -0.8f;
            float phoneAdd = 0.45f;
            float itemsMod = 0.16f;
            if(GameManager.dificultad == 0)
            {
                t = 0.3f;
                relaxedMod = -1f;
                phoneAdd = 0.47f;
                itemsMod = 0.18f;
            }
            else if(GameManager.dificultad == 2)
            {
                t = 1f;
                relaxedMod = -0.7f;
                phoneAdd = 0.43f;
                itemsMod = 0.17f;
            }
            t = t + (GameManager.handSlider? 1f: 0f) + ((GameManager.totalItems*itemsMod)+(GameManager.phoneStolen?0f:phoneAdd))*(GameManager.relaxed?relaxedMod: 0f);
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
