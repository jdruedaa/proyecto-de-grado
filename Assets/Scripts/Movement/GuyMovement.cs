using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{
    public Sprite newSprite;
    public Sprite sinMaleta;
    public static GuyMovement guy;
    private bool b = true;
    public float tiempo;
    private bool maleta;
    public MaletaScript mlta;
    public GameObject maletaGO;
    // Start is called before the first frame update
    void Start()
    {
        tiempo = Time.time;
        mlta = maletaGO.GetComponent<MaletaScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float t2 = (Time.time - tiempo) % 30f;
        if(GameManager.level > 1)
        {
            if (!GameManager.intro && t2 > 29f && t2 < 30f && !GameManager.maletaDown)
            {
                //Debug.Log("drop at " + Time.time);
                float chance = 100;
                chance -= 10 * GameManager.mejoras[1];
                if(Random.Range(0,100) <= chance)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sinMaleta;
                    mlta.drop();
                }
            }
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
