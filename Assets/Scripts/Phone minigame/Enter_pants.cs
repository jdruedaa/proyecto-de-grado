using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Enter_pants : MonoBehaviour
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

    void Awake()
    {        
        CharacterScript child = CharacterScript.charact;
        if(child != null)
        {
            child.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            child.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
            child.gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
            child.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = true;
            child.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().enabled = true;
            /*if(GameManager.maletaDown)
            {
                child.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().enabled = true;
            }*/
        }
    }

    //If your mouse hovers over the GameObject with the script attached, output this message
    void OnMouseOver()
    {
        Debug.Log("touch");
        if(ready && !GameManager.intro){
            ready = false;
            SceneManager.LoadScene("Practice scene");
            Phone_minigame.main_phone.act = true;
        }
    }
}
