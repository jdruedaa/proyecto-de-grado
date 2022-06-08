using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    public GameObject canvas;
    public static bool upgradeScreen = true;
    public static Text[] texts;
    public static int[] preciosAct;
    public Text title;
    public Text texto1;
    public Text texto2;

    public static int actualId = 0;
    //public Text texto3;
    //public Text texto4;
    //public int[] preciosCel = {2000,3500,5000};
    //public int[] preciosMaleta = {1500,2800,4100};
    //public int[] preciosEstres = {2500,4500,6500};
    
    // Start is called before the first frame update
    void Start()
    {
        preciosAct = new int[3];
        texts = new Text[2];
        texts[0] = title;
        texts[1] = texto2;
        texto1.text = "Tienes " + GameManager.accScore + " puntos";
        //Preferiría que en vez de copy paste a esto de abajo se haga un método general que asigne todos 
        //los text a la vez (esto es un método de "placeholder") (como en results)
        //texto3.text = preciosCel[GameManager.mejoras[1]];
        //texto4.text = preciosCel[GameManager.mejoras[2]];
    }

    // Update is called once per frame
    void Update()
    {        
        if(canvas.transform.position.x >=15.5f && upgradeScreen)
        {
            canvas.transform.position = new Vector3(16f,-1f,0f);
        }
        else if(upgradeScreen){
            Vector3 movement = new Vector3(60f*Time.deltaTime, 0f, 0);
            canvas.transform.Translate(movement);
        }  
        else if(canvas.transform.position.x <=0f && !upgradeScreen){
            canvas.transform.position = new Vector3(0f,-1f,0f);
        }
        else if(!upgradeScreen){
            Vector3 movement = new Vector3(-60f*Time.deltaTime, 0f, 0);
            canvas.transform.Translate(movement);
        }  
    }

    public void mejorar()
    {
        int mejoraActual = 3;
        if(actualId < 3){
            mejoraActual = GameManager.mejoras[actualId];
        } else if(actualId < 5){
            mejoraActual = GameManager.consumibles[actualId-3];
        } else{
            //coofee
        }
        int puntajeActual = GameManager.accScore;
        if(mejoraActual <= 2)
        {
            int precioMejora = preciosAct[mejoraActual];
            if(puntajeActual >= precioMejora)
            {
                mejoraActual ++;
                if(actualId < 3){
                    GameManager.mejoras[actualId] = mejoraActual;
                } else if(actualId < 5){
                    GameManager.consumibles[actualId-3] = mejoraActual;
                } else{
                    //coofee
                }
                GameManager.accScore = puntajeActual - precioMejora;
                texto1.text = "Tienes " + GameManager.accScore + " puntos";
                if(mejoraActual >= 3)
                {
                    texto2.text = "Sold out";
                }
                else
                {
                    texto2.text = "$" + preciosAct[GameManager.mejoras[0]];
                }
            }
        }
    }

    public void noMejorar()
    {
        if(!upgradeScreen){
            upgradeScreen = true;
        }
    }

    public void goBack()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void devPoints()
    {
        GameManager.accScore += 50000;
        texto1.text = "Tienes " + GameManager.accScore + " puntos";
    }
}