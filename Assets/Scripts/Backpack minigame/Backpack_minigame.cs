using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Backpack_minigame : MonoBehaviour
{
    public int contadorItems;
    public Sprite exitSprite;
    public bool[] itemsVivos;
    public float timeStart;
    public Text texto;
    public float restante;
    public bool timerIsRunning;
    //public CapsuleCollider2D colliderMaleta;
    /*public gameObject tablet;
    public gameObject redBook;
    public gameObject blueBook;
    public gameObject greenBook;
    public gameObject keys;*/
    // Start is called before the first frame update
    void Start()
    {
        contadorItems = 0;
        int i = 0;
        bool[] items = GameManager.itemsMaleta;
        itemsVivos = new bool[5];
        while(i < items.Length)
        {
            itemsVivos[i] = false;
            if(items[i])
            {
                contadorItems++;
            }
            i++;
        }
        timeStart = CharacterScript.charact.gameObject.transform.GetChild(4).GetComponent<MaletaScript>().timeStart;
        timerIsRunning = true;
        float duration = 40f;
        if(GameManager.dificultad == 0)
        {
            duration += 10f;
        }
        else if(GameManager.dificultad == 2)
        {
            duration -= 20f;
        }
        restante = duration - ((5-contadorItems)*4) - (Time.time - timeStart);
        //colliderMaleta = GetComponent<CapsuleCollider2D>();
        /*cuando hagamos posiciones random debe instanciar
        //items = GameManager.itemsMaleta();
        //if(items[0])
        //{
        }*/          
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            if (restante > 0)
            {
                restante -= Time.deltaTime;
                DisplayTime(restante);
            }
            else
            {
                //Debug.Log("Time has run out!");
                restante = 0;
                timerIsRunning = false;
            }
        }
    
        /*if(prevRestante - restante >= 1)
        {
            texto.text = string.Format("Tiempo restante: {0}", restante);
            Debug.Log(texto.text);
        }
        prevRestante = restante;*/

        if(contadorItems <= 0) 
        {
            //Debug.Log("no items");
            BackToBus();
        }
        else if(!timerIsRunning)
        {
            //BadEnd();
            GameManager.itemsMaleta = itemsVivos;
            int i = 0;
            while(i < itemsVivos.Length)
            {
                if(!itemsVivos[i])
                {
                    GameManager.motivosRobo[i+1] = "(Distracción)";
                }
                i++;
            }
            while(contadorItems > 0)
            {
                SliderManager.bar.moveSlider(10f);
                contadorItems--;
                GameManager.totalItems--;
            }
            if(GameManager.totalItems < (Mathf.Ceil(itemsVivos.Length/2)))
            {
                GameManager.gameOverReason = "Se perdieron 4 o más objetos de la maleta.";
                GameManager.GameOver();
            }
            BackToBus();
        }
        //else if timer acabado BadEnd(); BackToBus();
        
    }

    void Awake()
    {
        CharacterScript child = CharacterScript.charact;
        if(child != null)
        {
            child.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            child.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            child.gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
            child.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
            child.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        texto.text = "Quedan " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "ItemMaleta")
        {
            Backpack_minigame_item item =  col.gameObject.GetComponent<Backpack_minigame_item>();
            if(item.save)
            {
                itemsVivos[item.identifier] = true;
                item.saved();
                contadorItems--;
            }
        }
    }

    void BackToBus()
    {
        GameManager.maletaDown = false;
        SceneManager.LoadScene("test scene");
        Transform guy = CharacterScript.charact.gameObject.transform.GetChild(0);
        guy.GetComponent<SpriteRenderer>().sprite = exitSprite;
        guy.GetComponent<GuyMovement>().mlta.restart();
    }
}
