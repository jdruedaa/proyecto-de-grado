using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text texto1;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Game Over")
        {
            texto1.text = GameManager.gameOverReason;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reiniciar()
    {
        GameManager.instance.Reset();
        SceneManager.LoadScene("Main menu");
    }

    public void NextLevel()
    {
        if(GameManager.level == GameManager.lastLevel)
        {
            GameManager.instance.Reset();
            GameManager.level = 1;
            SceneManager.LoadScene("Main menu");
        }
        else
        {
            GameManager.instance.Reset();
            GameManager.level += 1;
            SceneManager.LoadScene("Main menu");
        }
    }
}
