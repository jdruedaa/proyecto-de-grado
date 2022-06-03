using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class chocolate : MonoBehaviour
{
    public GameObject sliderManager;
    public int consumibleActual;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        consumibleActual = GameManager.consumibles[0];
        if(consumibleActual > 0)
        {
            gameObject.SetActive(true);    
        }
    }

    void OnMouseDown()
    {
        if(!GameManager.intro)
        {
            if(consumibleActual > 0)
            {
                consumibleActual -= 1;
                GameManager.consumibles[0] = consumibleActual;
                sliderManager.GetComponent<SliderManager>().chocolate();
            }
        }
    }
}
