using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaMovement : MonoBehaviour
{
    public Sprite newSprite;
    public GameObject textoTuto;


    // Start is called before the first frame update
    void Start()
    {
        textoTuto.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x <=16.0f)
        {
            Vector3 movement = new Vector3(2.75f*Time.deltaTime, 0, 0);
            transform.Translate(movement);
        }
        else
        {
            this.GetComponent<Animator>().enabled = false;
            if(GameManager.level == 1)
            {
                if (textoTuto != null && !textoTuto.activeSelf && (GameManager.tutorialCel || GameManager.tutorialVent || GameManager.intro))
                {
                    textoTuto.SetActive(true);
                }
            }
            else if(GameManager.level == 2)
            {
                if (textoTuto != null && !textoTuto.activeSelf && GameManager.tutorialMaleta)
                {
                    textoTuto.SetActive(true);
                }
            }
            else
            {
                
            }
        }
    }
}

