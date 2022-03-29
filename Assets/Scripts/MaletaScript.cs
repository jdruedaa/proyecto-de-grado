using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaletaScript : MonoBehaviour
{
    public float timeStart;
    public static MaletaScript maleta;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, -0.1f);
        timeStart = Time.time + 2f;
        maleta = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("Backpack minigame");
    }

    void Awake()
    {
        if(!GameManager.maletaDown)
        {
            transform.position = new Vector2(1.45f,-2.52f);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, -0.1f);
            timeStart = Time.time + 2f;
            maleta = this;
            enabled = false;
            GameManager.maletaDown = true;
            Debug.Log(transform.position);
            CharacterScript.charact.gameObject.transform.GetChild(0).GetComponent<GuyMovement>().mlta = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
