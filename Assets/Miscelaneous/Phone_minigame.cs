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
    public bool act;
    public static Phone_minigame main_phone;

    // Start is called before the first frame update
    void Start()
    {
        movement = false;
        target = new Vector2(-10,0);
        position = gameObject.transform.position;
        hand = false;
        act = true;
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
            if((Vector2)transform.position == target)
            {
                transform.position = new Vector2(0,0);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0);
            if((Vector2)transform.position == target)
            {
                transform.position = new Vector2(0,0);
            }
        }
    }

    void OnMouseDrag()
    {
        if(act)
        {
        hand = false;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
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
