using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Window_leave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseDown()
    {
        if(GameManager.tutorialVent)
        {
            GameManager.tutorialVent = false;
            GameManager.intro = true;
        }
        GameManager.relaxed = false;
        SceneManager.LoadScene("test scene");
    }
}
