﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Phone_minigame : MonoBehaviour
{
    public bool movement;
    public Vector2 target;
    public float speed = 20f;
    public Vector2 position;
    public bool hand;
    public bool holding;
    public bool canGrab;
    public bool act;
    public static Phone_minigame main_phone;
    private Rigidbody2D rgb;
    public bool steal;
    public float stealAttemptTime;
    public bool stolen;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(5,0);
        movement = false;
        target = new Vector2(-7,0);
        position = gameObject.transform.position;
        hand = false;
        holding = false;
        canGrab = true;
        act = true;
        rgb = GetComponent<Rigidbody2D>();
        rgb.constraints = RigidbodyConstraints2D.FreezeRotation;
        steal = false;
        stolen = false;
        Trans_movement();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == gameObject.tag) 
            {
                if(act)
                {
                    hand = !hand;
                }
                //add hand sprite on top of phone, tal vez usar un tag para que ambos objetos vayan juntos
            }
        }
        if(steal)
        {
            Debug.Log("Time: " + Time.time);
            Debug.Log("steal attempt:" + stealAttemptTime);
            if(Time.time >= stealAttemptTime)
            {
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
            if(!hand && !holding)
            {
                stealAttemptTime = Time.time + 10f;
                steal = true;
                Debug.Log("Robable");
            }
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
                    Debug.Log("Robable");
                }
            }
            else
            {
                stealAttemptTime = Time.time + 5f;
                steal = false;
                Debug.Log("No Robable");
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pants")
        {
            stealAttemptTime = Time.time + 5f;
            steal = false;
            Debug.Log("No Robable");
        }
    }

    void OnMouseDrag()
    {
        if(act)
        {
            if(canGrab)
            {
                hand = false;
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
        StartCoroutine(WaitMove(10));
        Movement(1,3);
    }

    public void Movement(int time, int sped)
    {
        StartCoroutine(Waiting(time,sped));
    }    

    IEnumerator Waiting(int time, int sped)
    {
        if(!hand && !movement){
            this.speed = sped;
            movement = true;
            yield return new WaitForSeconds(time);
            movement = false;
        }else if(!hand){
            StartCoroutine(Waiting(time,sped));
        }
    }

    IEnumerator WaitMove(int time)
    {
        yield return new WaitForSeconds(time);
        Trans_movement();
    }

    void StealAttempt()
    {
        if(Random.Range(0,100) <= 60)
        {
            Debug.Log("Celular Robado D:");
            //mejor mandar señal a otro lado de que se robaron el celular?
            GameManager.phoneStolen = true;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Intento de robo fallido");
        }
    }
}