using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text texto1;
    // Start is called before the first frame update
    void Start()
    {
        texto1.text = GameManager.gameOverReason;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReiniciarJuego()
    {
        GameManager.instance.Reset();
        SceneManager.LoadScene("Main menu");
    }
}
