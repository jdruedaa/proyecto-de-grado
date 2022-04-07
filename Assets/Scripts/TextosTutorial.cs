using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosTutorial : MonoBehaviour
{
    string texto1 = "Tu objetivo es intentar no ser robado mientras haces lo posible para mantener un nivel bajo de estrés";
    string texto2 = "Tu eres el joven sentado con camiseta roja, tienes que estar pendiente de tus objetos en tu maleta y tu celular";
    string texto3 = "En la parte de arriba de la pantalla puedes ver la barra de estrés, esta subira con el tiempo y si te roban algo";
    string texto4 = "Para evitar que te roben el celular puedes acomodarlo en el fondo de tu bolsillo";
    string texto5 = "Puedes acceder a tu bolsillo pasando el mouse sobre la barra azul en la parte de abajo de la pantalla";
    string texto6 = "Dentro de tu bolsillo puedes arrastrar el celular a la derecha para evitar que sea robable, para salir del bolsillo vuelve a pasar el mouse por la barra azul";
    string texto7 = "Durante el juego es posible que se caiga tu maleta, si esto pasa tienes que recoger tus cosas para evitar que sean robadas";
    string texto8 = "Cuando tu maleta se caiga haz click sobre ella para empezar el minijuego";
    string texto9 = "Arrastra los objetos del suelo a la maleta para terminar el minijuego";
    int contador = 1;
    public Button continuar;
    public Text textoTutorial;
    public Text textoBoton;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        textoTutorial.text = texto1;
        contador = 1;
        continuar.onClick.AddListener(cambiarTexto);
    }

    public void cambiarTexto()
    {
        switch (contador)
        {
            case 9:
                Time.timeScale = 1;
                canvas.enabled = false;
                break;
            case 8:
                textoTutorial.text = texto9;
                textoBoton.text = "Finalizar";
                break;
            case 7:
                textoTutorial.text = texto8;
                break;
            case 6:
                textoTutorial.text = texto7;
                break;
            case 5:
                textoTutorial.text = texto6;
                break;
            case 4:
                textoTutorial.text = texto5;
                break;
            case 3:
                textoTutorial.text = texto4;
                break;
            case 2:
                break;
                textoTutorial.text = texto3;
            case 1:
                textoTutorial.text = texto2;
                break;
            default:
                break;
        }
        contador += 1;
        Debug.Log(contador);
    }
}
