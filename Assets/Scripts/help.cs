using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class help : MonoBehaviour
{
    public GameObject tutorial;
    public Text nivel;

    // Start is called before the first frame update
    void Start()
    {
        nivel.text += "" + GameManager.level;
    }

    void OnMouseDown()
    {
        if(!GameManager.intro)
        {
            if (tutorial!=null)
            {
                tutorial.GetComponent<TextosTutorial>().restart();
                tutorial.gameObject.SetActive(true);
            }
        }
    }
}
