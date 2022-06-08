using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Phone_tutorial : MonoBehaviour
{
    public GameObject fondo;
    public GameObject arrowBack;
    public Text textTuto;
    public SpriteRenderer sRender;
    
    void Start()
    {
        sRender = gameObject.GetComponent<SpriteRenderer>();
        Color color = sRender.color;
        color.a = 0;
        sRender.color = color;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void startTutorial()
    {
        gameObject.SetActive(true);
        StartCoroutine(StartTuto());
    }
    
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Phone")
        {
            Phone_minigame phone = col.gameObject.GetComponent<Phone_minigame>();
            if(!phone.holding)
            {
               StartCoroutine(EndTuto(phone));
            }
        }
    }

    private IEnumerator StartTuto()
    {
        yield return new WaitForSeconds(1.1f);
        Color color = sRender.color;
        color.a = 255;
        sRender.color = color;
        fondo.SetActive(true);
    }

    private IEnumerator EndTuto(Phone_minigame phone)
    {
        textTuto.text = "Bien hecho! Recuerda hacerlo frecuentemente \n para no perder tu celular.";
        fondo.SetActive(false);
        Color color = sRender.color;
        color.a = 0;
        sRender.color = color;
        GameManager.tutorialCel = false;
        phone.canGrab = false;
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        arrowBack.SetActive(true);
    }
}
