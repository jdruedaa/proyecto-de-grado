using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    public Text texto1;
    public Text texto2;
    //public Text texto3;
    //public Text texto4;
    public int[] preciosCel = {2000,3500,5000};
    //public int[] preciosMaleta = {1500,2800,4100};
    //public int[] preciosEstres = {2500,4500,6500};
    
    // Start is called before the first frame update
    void Start()
    {
        texto1.text = "Tienes " + GameManager.accScore + " puntos";
        //Preferiría que en vez de copy paste a esto de abajo se haga un método general que asigne todos 
        //los text a la vez (esto es un método de "placeholder") (como en results)
        int mejoraActualCel = GameManager.mejoras[0];
        if(mejoraActualCel >= 3)
        {
            texto2.text = "Sold out";
        }
        else
        {
            texto2.text = "" + preciosCel[mejoraActualCel];
        }
        //texto3.text = preciosCel[GameManager.mejoras[1]];
        //texto4.text = preciosCel[GameManager.mejoras[2]];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mejorarCelular()
    {
        int mejoraActual = GameManager.mejoras[0];
        int puntajeActual = GameManager.accScore;
        if(mejoraActual <= 2)
        {
            int precioMejora = preciosCel[mejoraActual];
            if(puntajeActual >= precioMejora)
            {
                mejoraActual ++;
                GameManager.mejoras[0] = mejoraActual;
                GameManager.accScore = puntajeActual - precioMejora;
                texto1.text = "Tienes " + GameManager.accScore + " puntos";
                if(mejoraActual >= 3)
                {
                    texto2.text = "Sold out";
                }
                else
                {
                    texto2.text = "" + preciosCel[GameManager.mejoras[0]];
                }
            }
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