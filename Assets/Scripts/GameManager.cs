using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool phoneStolen;
    public static GameManager instance;

    void Start()
    {
        phoneStolen = false;
    }

    void Update()
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

