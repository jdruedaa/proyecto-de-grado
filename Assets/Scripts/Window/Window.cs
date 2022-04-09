using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Window : MonoBehaviour
{
    public SpriteRenderer sRender;
    // Start is called before the first frame update
    void Start()
    {
        sRender = gameObject.GetComponent<SpriteRenderer>();
        Color color = Color.yellow;
        color.a = 0;
        sRender.material.color = color;
    }

    //If your mouse hovers over the GameObject with the script attached, output this message
    void OnMouseOver()
    {
        if(!GameManager.intro)
        {
            Color color = Color.yellow;
            color.a = 0.4f;
            sRender.material.color = color;
        }
    }

    void OnMouseExit()
    {
        if(!GameManager.intro)
        {
            Color color = Color.yellow;
            color.a = 0;
            sRender.material.color = color;
        }
    }

    void OnMouseDown()
    {
        if(!GameManager.intro)
        {
            GameManager.relaxed = true;
            SceneManager.LoadScene("Window scene");
        }
    }
}
