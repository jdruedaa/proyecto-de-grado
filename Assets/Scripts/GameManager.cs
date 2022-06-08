using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool phoneStolen;
    public static bool estaFrenado;
    public static bool intro;
    public static bool end;
    public static bool relaxed;
    public static bool maletaDown;
    public static bool firstReaction;
    public static bool handSlider;
    public static GameManager instance;
    public static bool[] itemsMaleta;
    //mejoras[0] -> nivel celular, [1] -> nivel maleta, [2] -> nivel x
    public static int[] mejoras = {0,0,0};
    //consumibles[0] -> número de chocolates, [1] -> número de x
    public static int[] consumibles = {0,0};
    public static string[] motivosRobo;
    public static int accScore = 0;
    public static float totalItems = 5f;
    //dificultad : 0 -> fácil, 1 -> medio (juego base), 2 -> difícil
    public static int dificultad = 1;
    public static string gameOverReason = "";
    public static int level = 1;
    public static int lastLevel = 3;

    void Start()
    {
        phoneStolen = false;
        intro = true;
        end = false;
        relaxed = false;
        maletaDown = false;
        estaFrenado = false;
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

    public static void GameOver()
    {
        end = true;
        SceneManager.LoadScene("Game Over");
        var go = new GameObject("first");
        DontDestroyOnLoad(go);
        foreach(var root in go.scene.GetRootGameObjects())
        {
            if(root.tag == "Admin")
            {

            }
            else
            {
                Destroy(root);
            }
        }
    }

    public void Reset()
    {
        Start();
    }
}

