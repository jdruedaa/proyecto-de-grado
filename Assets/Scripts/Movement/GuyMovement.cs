using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{
    public Sprite newSprite;
    public Sprite sinMaleta;
    public static GuyMovement guy;
    private bool b = true;
    float tiempo;
    private bool maleta;
    public GameObject mlta;
    // Start is called before the first frame update
    void Start()
    {
        tiempo = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float t2 = (Time.time - tiempo) % 20;
        if (t2 > 19.5f && t2 < 20 && !maleta)
        {
            maleta = true;
            this.GetComponent<SpriteRenderer>().sprite = sinMaleta;
            GameManager.maletaDown = true;
            mlta.SetActive(true);
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
    }
}
