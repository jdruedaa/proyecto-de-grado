using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaletaScript : MonoBehaviour
{
    public float timeStart;
    public static MaletaScript maleta;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        timeStart = Time.time + 2f;
        maleta = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.velocity.y == 0)
        {
            rb.gravityScale = 0;
        }
    }

    void OnMouseDown()
    {
        if(!GameManager.intro){
            SceneManager.LoadScene("Backpack minigame");
        }
    }

    public void restart()
    {
        rb.gravityScale = 0;
        transform.position = new Vector2(1.458343f,-2.521799f);
        gameObject.SetActive(false);
        Debug.Log(transform.position);
    }

    public void drop()
    {
        transform.position = new Vector2(1.458343f,-2.521799f);
        gameObject.SetActive(true);
        rb.gravityScale = 1.5f;
        timeStart = Time.time + 2f;
        GameManager.maletaDown = true;
    }

    void Awake()
    {
        if(!GameManager.maletaDown)
        {
            rb = this.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            transform.position = new Vector2(1.458343f,-2.521799f);
            timeStart = Time.time + 2f;
            maleta = this;
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
