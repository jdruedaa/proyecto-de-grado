using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene("test scene");
    }

    public void Tienda()
    {
        SceneManager.LoadScene("Tienda Temp");
    }

    public void Dificultad()
    {
        SceneManager.LoadScene("Select dificulty");
    }
}
