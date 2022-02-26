using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Phone_minigame : MonoBehaviour
{
    public bool movement;
    public Vector2 target;
    public float speed = 2f;
    public Vector2 position;
    public bool hand;

    // Start is called before the first frame update
    void Start()
    {
        movement = true;
        target = new Vector2(-10,-10);
        position = gameObject.transform.position;
        hand = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == gameObject.tag) 
            {
                hand = !hand;
                //add hand sprite on top of phone, tal vez usar un tag para que ambos objetos vayan juntos
            }
        }
        if(movement && !hand)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
            if((Vector2)transform.position == target)
            {
                transform.position = new Vector2(0,0);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0);
            if((Vector2)transform.position == target)
            {
                transform.position = new Vector2(0,0);
            }
        }
    }

    void OnMouseUp()
    {
       if(!hand)
       {
           movement = true;
       }
    }

    void OnMouseDrag()
    {
        hand = false;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
