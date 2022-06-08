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
    public bool win = false;
    public float startingTime;
    public static float prevTime = -1f;

    void Start()
    {
        sl = slider.GetComponent<Slider>();
        timer = 0;
        song.Play();
        active = false;
        win = false;
    }
    public void moveSlider(float f)
    {
        if(GameManager.tutorialVent || GameManager.intro)
        {
            if(value + f > 30)
            {
                value = 30;
            }
            else
            {
                value += f;
            }
        }
        else
        {
            value += f;
        }
        if(sl != null){
            if(GameManager.tutorialVent || GameManager.intro)
            {
                if(sl.value + f > 30)
                {
                    sl.value = 30;
                }
                else
                {
                    sl.value += f;
                }
            }
            else
            {
                sl.value += f;
            }
            texto.text = string.Format("Nivel de estrés {0}/100", Mathf.Floor(sl.value));
        }
        if(sl.value >= 100)
        {
            GameManager.gameOverReason = "Tu nivel de estrés llegó al máximo y te bajaste antes de tu destino.";
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

    public static void StartTime()
    {
        prevTime = Time.time;
    }

    void FixedUpdate()
    {
        if(!GameManager.intro && !GameManager.end)
        {
            float t = 0.5f;
            float relaxedMod = -0.8f;
            //float phoneAdd = 0.45f;
            float itemsMod = 0.16f;
            if(GameManager.dificultad == 0)
            {
                t = 0.3f;
                relaxedMod = -1f;
                //phoneAdd = 0.47f;
                itemsMod = 0.18f;
            }
            else if(GameManager.dificultad == 2)
            {
                t = 1f;
                relaxedMod = -0.6f;
                //phoneAdd = 0.43f;
                itemsMod = 0.17f;
            }
            if(GameManager.level == 1)
            {
                t += 0.8f;
                relaxedMod += 0.2f;
                t = (GameManager.handSlider? 1f: 0f) + (GameManager.relaxed? t * relaxedMod: t);
            }
            else
            {
                t = (GameManager.handSlider? 1f: 0f) + (GameManager.relaxed? ((GameManager.totalItems*itemsMod)+t) * relaxedMod: t);
            }
            //t = t + (GameManager.handSlider? 1f: 0f) + ((GameManager.totalItems*itemsMod)+(GameManager.phoneStolen?0f:phoneAdd))*(GameManager.relaxed?relaxedMod: 0f);
            moveSlider(t * Time.deltaTime);
        }
        if(value >= 50f && !active){
            ChangeSong();
            active = true;
        }
        float currentTime = Time.time;
        if(prevTime != -1f)
        {
            startingTime = prevTime;
            timer = currentTime - startingTime;
            if((GameManager.level == 1 && timer >= 130f)||(GameManager.level >1 && timer >= 300f)||win)
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
