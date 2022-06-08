using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Exit_pants : MonoBehaviour
{
    public bool ready = false;
    public GameObject phone_tutorial;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.tutorialCel)
        {
            Time.timeScale = 1;
            StartCoroutine(BeginTutorial());
        }
        StartCoroutine(Waiting());
    }

    IEnumerator BeginTutorial()
    {
        yield return new WaitForSeconds(1);
        phone_tutorial.GetComponent<Phone_tutorial>().startTutorial();
    }
    
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1);
        ready = true;
    }

    void Awake()
    {        
        CharacterScript.charact.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        CharacterScript.charact.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        CharacterScript.charact.gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
        CharacterScript.charact.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
        CharacterScript.charact.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().enabled = false;
    }

    //If your mouse hovers over the GameObject with the script attached, output this message
    void OnMouseOver()
    {
        if(ready && !GameManager.tutorialCel){
            ready = false;
            if(GameManager.phoneStolen && GameManager.firstReaction)
            {
                SliderManager.bar.moveSlider(25f);
                GameManager.firstReaction = false;
            }
            SceneManager.LoadScene("test scene");
            Phone_minigame.main_phone.act = false;
        }
    }
}