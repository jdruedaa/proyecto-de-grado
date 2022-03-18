using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Backpack_minigame_item : MonoBehaviour
{
    public bool canGrab;
    private Rigidbody2D rgb;
    public bool save;
    public int identifier;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "TabletTurnedOff")
        {
            transform.position = new Vector2(-6.26f, 0.51f);
            identifier = 0;
        }
        else if(gameObject.name == "Blue Book")
        {
            transform.position = new Vector2(3.9f, 1.16f);
            identifier = 1;
        }
        else if(gameObject.name == "red-book")
        {
            transform.position = new Vector2(6.14f, -1.06f);
            identifier = 2;
        }
        else if(gameObject.name == "Keys")
        {
            transform.position = new Vector2(-7.05f, -3.3f);
            identifier = 3;
        }
        else
        {
            transform.position = new Vector2(-1.96f, 1.26f);
            identifier = 4;
        }
        if(!GameManager.itemsMaleta[identifier])
        {
            Destroy(gameObject);
        }
        canGrab = true;
        save = true;
        rgb = GetComponent<Rigidbody2D>();
        rgb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position, 0);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Piso")
        {
            canGrab = false;
            Vector2 point = col.collider.ClosestPoint(transform.position);
            transform.position = point;
            canGrab = true;
        }
    }

    void OnMouseDrag()
    {
        if(canGrab)
        {
            save = false;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }   

    void OnMouseUp()
    {
        save = true;
    }

    public void saved()
    {
        GameManager.itemsMaleta[identifier] = false;
        //spinning and shrinking animation
        Destroy(gameObject);
    }
}
