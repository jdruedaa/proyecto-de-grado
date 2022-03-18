using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public static CharacterScript charact;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() 
    {
        if(charact == null){
            DontDestroyOnLoad(gameObject);
            charact = this;
        }else{
            Destroy(gameObject);
        }

    }
}
