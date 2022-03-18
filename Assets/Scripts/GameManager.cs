using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool phoneStolen;
    public static bool intro;
    public static bool maletaDown;
    public static GameManager instance;
    public static bool[] itemsMaleta;

    void Start()
    {
        phoneStolen = false;
        intro = true;
        maletaDown = false;
        itemsMaleta = new bool[5];
        int i = 0;
        while(i < itemsMaleta.Length)
        {
            itemsMaleta[i] = true;
            i++;
        }
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

