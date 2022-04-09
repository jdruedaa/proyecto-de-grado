using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class help : MonoBehaviour
{
    public GameObject tutorial;

    // Start is called before the first frame update
    void Start()
    {

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
