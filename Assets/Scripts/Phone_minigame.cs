using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Phone_minigame : MonoBehaviour
{
    public bool movement;
    public Vector2 target;
    public float speed = 20f;
    public Vector2 position;
    public bool hand;
    public bool holding;
    public bool canGrab;
    public bool act;
    public static Phone_minigame main_phone;
    private Rigidbody2D rgb;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(5,0);
        movement = false;
        target = new Vector2(-7,0);
        position = gameObject.transform.position;
        hand = false;
        holding = false;
        canGrab = true;
        act = true;
        rgb = GetComponent<Rigidbody2D>();
        rgb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Trans_movement();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == gameObject.tag) 
            {
                if(act)
                {
                    hand = !hand;
                }
                //add hand sprite on top of phone, tal vez usar un tag para que ambos objetos vayan juntos
            }
        }
        if(movement && !hand)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Pants")
        {
            canGrab = false;
            Vector2 point = col.collider.ClosestPoint(transform.position);
            transform.position = point;
            canGrab = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pants")
        {
            if(!hand && !holding)
            {
                Debug.Log("robable");
            }
        }
        //Signal "stealable" (true)
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pants")
        {
            if(!hand && !holding)
            {
                Debug.Log("robable");
            }
        }
        //Signal "stealable" (true)
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Pants")
        {
            Debug.Log("no robable");
        }
        //Remove signal "stealable" (false)
    }

    void OnMouseDrag()
    {
        if(act)
        {
            if(canGrab)
            {
                hand = false;
                holding = true;
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = Camera.main.nearClipPlane;
                transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            }
        }
    }   

    void OnMouseUp()
    {
        holding = false;
    } 
 
    void Awake() 
    {
        if(main_phone == null){
            DontDestroyOnLoad(this.gameObject);
            main_phone = this;
        }else{
            Destroy(this.gameObject);
        }

    }

    void Trans_movement()
    {
        StartCoroutine(WaitMove(10));
        Movement(1,6);
    }

    public void Movement(int time, int sped)
    {
        StartCoroutine(Waiting(time,sped));
    }    

    IEnumerator Waiting(int time, int sped)
    {
        if(!hand && !movement){
            this.speed = sped;
            movement = true;
            yield return new WaitForSeconds(time);
            movement = false;
        }else if(!hand){
            StartCoroutine(Waiting(time,sped));
        }
    }

    IEnumerator WaitMove(int time)
    {
        yield return new WaitForSeconds(time);
        Trans_movement();
    }
}
