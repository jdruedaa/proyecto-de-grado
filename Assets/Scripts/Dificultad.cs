using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dificultad : MonoBehaviour
{
    public Button facil;
    public Button baseMedio;
    public Button dificil;
    public Color32 selColor = new Color32(241,210,14,255);
    public Text texto;
    
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.dificultad == 0)
        {
            facil.GetComponent<Image>().color = selColor;
            texto.text = "Para jugadores nuevos";
        }
        else if(GameManager.dificultad == 2)
        {
            dificil.GetComponent<Image>().color = selColor;
            texto.text = "Para jugadores experimentados buscando un reto";
        }
        else
        {
            baseMedio.GetComponent<Image>().color = selColor;
            texto.text = "Juego equilibrado";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Facil()
    {
        GameManager.dificultad = 0;
        facil.GetComponent<Image>().color = selColor;
        baseMedio.GetComponent<Image>().color = Color.white;
        dificil.GetComponent<Image>().color = Color.white;
        texto.text = "Para jugadores nuevos";
    }

    public void BaseMedio()
    {
        GameManager.dificultad = 1;
        baseMedio.GetComponent<Image>().color = selColor;
        facil.GetComponent<Image>().color = Color.white;
        dificil.GetComponent<Image>().color = Color.white;
        texto.text = "Juego equilibrado";
    }

    public void Dificil()
    {
        GameManager.dificultad = 2;
        dificil.GetComponent<Image>().color = selColor;
        baseMedio.GetComponent<Image>().color = Color.white;
        facil.GetComponent<Image>().color = Color.white;
        texto.text = "Para jugadores experimentados buscando un reto";
    }

    public void Volver()
    {
        SceneManager.LoadScene("Main menu");
    }
}
