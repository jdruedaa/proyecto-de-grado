﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Phone_minigame : MonoBehaviour
{
    public bool movement;
    public Vector2 target;
    public Vector2 targetTuto;
    public float speed = 0.1f;
    public float speedTuto;
    public Vector2 position;
    public bool hand;
    public bool holding;
    public bool canGrab;
    public bool act;
    public bool targetReached;
    public static Phone_minigame main_phone;
    private Rigidbody2D rgb;
    public bool steal;
    public float stealAttemptTime;
    public bool stolen;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.level == 1)
        {
            transform.position = new Vector2(98.85f,-40.3f);
        }
        else
        {
            transform.position = new Vector2(104.1f,-40.3f);
        }
        movement = false;
        target = new Vector2(92.1f,-40.3f);
        speedTuto = 1.1f;
        targetTuto = new Vector2(95.85f,-40.3f);
        position = gameObject.transform.position;
        hand = false;
        GameManager.handSlider = hand;
        holding = false;
        canGrab = true;
        act = true;
        targetReached = false;
        rgb = GetComponent<Rigidbody2D>();
        rgb.constraints = RigidbodyConstraints2D.FreezeRotation;
        steal = false;
        stolen = false;
        Trans_movement();
        Vibration();
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Practice scene")
        {
            if(GameManager.tutorialCel)
            {
                float step = speedTuto * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetTuto, step);
            }
            if(Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero);
                if (hit.collider != null && hit.collider.tag == gameObject.tag) 
                {
                    hand = !hand;
                    GameManager.handSlider = hand;
                    //add hand sprite on top of phone, tal vez usar un tag para que ambos objetos vayan juntos
                }
            }
        }
        if(steal && !GameManager.tutorialCel && !GameManager.tutorialVent)
        {
            if(Time.time >= stealAttemptTime)
            {
                //Debug.Log(Time.time);
                //Debug.Log("steal attempt:" + stealAttemptTime);
                StealAttempt();
                stealAttemptTime = Time.time + 5f;
            }
        }
        if(movement && !hand)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Pants")
        {
            canGrab = false;
            Vector2 point = col.collider.ClosestPoint(transform.position);
            transform.position = point;
            canGrab = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pants")
        {
            if(!hand && !holding && !GameManager.tutorialCel)
            {
                stealAttemptTime = Time.time + 10f;
                steal = true;
                //Debug.Log("Robable");
            }
            targetReached = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pants")
        {
            if(!hand && !holding)
            {
                if(!steal)
                {
                    stealAttemptTime = Time.time + 5f;
                    steal = true;
                    //Debug.Log("Robable");
                }
            }
            else
            {
                stealAttemptTime = Time.time + 5f;
                steal = false;
                //Debug.Log("No Robable");
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pants")
        {
            stealAttemptTime = Time.time + 5f;
            steal = false;
            //Debug.Log("No Robable");
            targetReached = false;
        }
    }

    void OnMouseDrag()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Practice scene")
        {
            if(canGrab)
            {
                hand = false;
                GameManager.handSlider = hand;
                holding = true;
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = Camera.main.nearClipPlane;
                transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            }
        }
    }   

    void OnMouseUp()
    {
        holding = false;
    } 
 
    void Awake() 
    {
        stolen = GameManager.phoneStolen;
        if(main_phone == null && !stolen){
            DontDestroyOnLoad(gameObject);
            main_phone = this;
        }else{
            Destroy(gameObject);
        }

    }

    void Trans_movement()
    {
        StartCoroutine(WaitMove(15));
        float[] sped = {2f,1.5f,1.25f,1f};
        float speedMod = 0f;
        if(GameManager.dificultad == 0)
        {
            speedMod = -1f;
        }
        else if(GameManager.dificultad == 2)
        {
            speedMod = 1f;
        }
        Movement(3,sped[GameManager.mejoras[0]] + speedMod);
    }

    void Vibration()
    {
        if(!hand && !holding && !targetReached){
            StartCoroutine(WaitVib(2));
        }
        float speed = 1f;
        if(GameManager.dificultad == 0)
        {
            speed -= 0.5f;
        }
        else if(GameManager.dificultad == 2)
        {
            speed += 0.5f;
        }
        Movement(1,1f);
    }

    public void Movement(int time, float sped)
    {
        StartCoroutine(Waiting(time,sped));
    }    

    IEnumerator Waiting(int time, float sped)
    {
        if(!hand && !GameManager.tutorialCel && !GameManager.tutorialVent && !GameManager.intro){
            yield return new WaitUntil(() => movement == false);
            movement = true;
            this.speed = sped;
            yield return new WaitForSeconds(time);
            movement = false;
        }
    }

    IEnumerator WaitMove(int time)
    {
        yield return new WaitForSeconds(time);
        Trans_movement();
    }

    IEnumerator WaitVib(int time)
    {
        yield return new WaitForSeconds(time);
        Vibration();
    }

    void StealAttempt()
    {
        if(Random.Range(0,100) <= 60)
        {
            //Debug.Log("Celular Robado D:");
            GameManager.phoneStolen = true;
            Destroy(gameObject);
            GameManager.motivosRobo[0] = "(Cosquilleo)";
            GameManager.gameOverReason = "Tu celular fue robado por cosquilleo.";
            GameManager.GameOver();
        }
        else
        {
            //Debug.Log("Intento de robo fallido");
        }
    }
}
