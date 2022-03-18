using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Backpack_minigame : MonoBehaviour
{
    //public CapsuleCollider2D colliderMaleta;
    /*public gameObject tablet;
    public gameObject redBook;
    public gameObject blueBook;
    public gameObject greenBook;
    public gameObject keys;*/
    // Start is called before the first frame update
    void Start()
    {
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

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "ItemMaleta")
        {
            Backpack_minigame_item item =  col.gameObject.GetComponent<Backpack_minigame_item>();
            if(item.save)
            {
                item.saved();
            }
        }
    }
}
