using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanMovement : MonoBehaviour
{
    public Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x >=7.2f)
        {
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = newSprite;
            transform.position = new Vector3(7.22f,-0.5f,0f);
            transform.localScale = new Vector3(1f,1f,1f);
        }
        else {
            Vector3 movement = new Vector3(2.75f*Time.deltaTime, 0, 0);
            transform.Translate(movement);
        }
    }
}
