using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Backpack_minigame : MonoBehaviour
{
    public int contadorItems;
    public Sprite exitSprite;
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
        while(i < items.Length)
        {
            if(items[i])
            {
                contadorItems++;
            }
            i++;
        }
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
        if(contadorItems <= 0) 
        {
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

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "ItemMaleta")
        {
            Backpack_minigame_item item =  col.gameObject.GetComponent<Backpack_minigame_item>();
            if(item.save)
            {
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
    }
}
