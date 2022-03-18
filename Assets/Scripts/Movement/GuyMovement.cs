using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{
    public Sprite newSprite;
    public Sprite sinMaleta;
    public static GuyMovement guy;
    public bool drop;
    private bool b = true;
    float tiempo;
    float tiempo2;
    private bool maleta;
    public GameObject mlta;
    // Start is called before the first frame update
    void Start()
    {
        tiempo = Time.time;
        drop = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(drop)
        {
            GameManager.maletaDown = true;
            mlta.SetActive(true);
        }
        float t2 = (Time.time - tiempo) % 120;
        if (t2 > 119.5f && t2 < 120 && !maleta)
        {
            maleta = true;
            this.GetComponent<SpriteRenderer>().sprite = sinMaleta;
            GameManager.maletaDown = true;
            mlta.SetActive(true);
            tiempo2 = Time.time;
        }
        if (transform.position.x >=-0.0f && b)
        {
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = newSprite;
            transform.position = new Vector3(0.1f,-0.9f,0f);
            b = false;
        }
        else if(b) {
            Vector3 movement = new Vector3(2.75f*Time.deltaTime, 0, 0);
            transform.Translate(movement);
        }
        if(maleta)
        {
            float t3 = (Time.time - tiempo2) % 60; 
            if (t3 > 59.5f && t3 < 60 && !maleta){

            }
        }
    }
}
