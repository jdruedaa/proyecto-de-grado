using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Exit_pants : MonoBehaviour
{
    public bool ready = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1);
        ready = true;
    }

    //If your mouse hovers over the GameObject with the script attached, output this message
    void OnMouseOver()
    {
        if(ready){
            ready = false;
            Phone_minigame.main_phone.act = false;
            SceneManager.LoadScene("Main Screen");
        }
    }
}