using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotUnload : MonoBehaviour
{

    public static NotUnload instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if (instance == null) 
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        { 
            Destroy(gameObject);
        }
    }

}
