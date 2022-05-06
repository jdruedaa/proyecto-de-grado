using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTrans : MonoBehaviour
{

    private bool b = true;
    public GameObject wheel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >=0f && b)
        {
            transform.position = new Vector3(0f,-0.5f,0f);
            b = false;
        }
        else if(b){
            Vector3 movement = new Vector3(2.75f*Time.deltaTime, 0, 0);
            transform.Translate(movement);
            wheel.transform.Rotate(0,0,-640f*Time.deltaTime);
        }  
        else{
          wheel.transform.Rotate(0,0,-320f*Time.deltaTime);
        }     
        
    }
}
