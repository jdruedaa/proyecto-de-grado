using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ÑeroMovement : MonoBehaviour
{

    private bool b = true;
    public Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x >=-2.8f && b)
        {
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = newSprite;
            transform.position = new Vector3(-2.73f,-0.9f,0f);
            b = false;
        }
        else if(b) {
            Vector3 movement = new Vector3(2.75f * Time.deltaTime, 0, 0);
            transform.Translate(movement);
        }
    }
}
