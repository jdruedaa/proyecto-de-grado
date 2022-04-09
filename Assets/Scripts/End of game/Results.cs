using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{
    public Text texto1;
    public Text texto2;
    public Text texto3;
    public int valor;
    // Start is called before the first frame update
    void Start()
    {
        texto1.text = "Celular:\nTablet:\nLibro azul:\nLibro rojo:\nLlaves:\nLibro verde:\nEstrés:";
        valor = 0;
        makeResults();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeResults()
    {
        if(!GameManager.phoneStolen)
        {
            texto2.text = "800";
            valor += 1000;
        }
        else
        {
            texto2.text = "Perdido " + GameManager.motivosRobo[0];
        }
        int i = 0;
        bool[] items = GameManager.itemsMaleta;
        while(i < items.Length)
        {
            if(items[i])
            {
                texto2.text += "\n200";
                valor += 200;
            }
            else
            {
                texto2.text += "\nPerdido " + GameManager.motivosRobo[i+1];
            }
            i++;
        }
        int stressScore = (100 - Mathf.FloorToInt(SliderManager.bar.sl.value)) * 10;
        texto2.text += "\n" + stressScore;
        valor += stressScore;
        texto3.text = "Total: " + valor;
        GameManager.accScore += valor;
    }
}