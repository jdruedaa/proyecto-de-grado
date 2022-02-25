using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone_minigame : MonoBehaviour
{
    public bool movement;
    public Vector2 target;
    public float speed = 2f;
    public Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        movement = true;
        target = new Vector2(-10,-10);
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(movement)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
            if((Vector2)transform.position == target)
            {
                transform.position = new Vector2(0,0);
            }
        }
    }
    
    void OnMouseDown()
    {
        movement = false;
    }

    void OnMouseUp()
    {
        movement = true;
    }

    void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
