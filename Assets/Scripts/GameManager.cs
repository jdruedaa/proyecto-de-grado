using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool phoneStolen;
    public static bool intro;
    public static bool end;
    public static bool relaxed;
    public static bool maletaDown;
    public static bool firstReaction;
    public static bool handSlider;
    public static GameManager instance;
    public static bool[] itemsMaleta;
    public static string[] motivosRobo;
    public static int accScore = 0;

    void Start()
    {
        phoneStolen = false;
        intro = true;
        end = false;
        relaxed = false;
        maletaDown = false;
        firstReaction = true;
        handSlider = false;
        itemsMaleta = new bool[5];
        int i = 0;
        while(i < itemsMaleta.Length)
        {
            itemsMaleta[i] = true;
            i++;
        }
        motivosRobo = new string[6];
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

    public void Reset()
    {
        Start();
    }
}

