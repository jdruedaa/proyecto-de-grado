using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    private Vector3 _startPosition;
    public GameObject go;
    private Vector3 go_sp;
    private bool pegarSalto = false;
    private bool volando = false;
    public GameObject sm;
    private SliderManager smm;

    void Start()
    {
        _startPosition = transform.position;
        go_sp = go.transform.position;
        smm = sm.GetComponent<SliderManager>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            pegarSalto = true;
        }
        if (pegarSalto)
        {
            if(transform.position.y < 4.4f && volando)
            {
                transform.position += new Vector3(0f,Time.deltaTime*3,0f);
                go.transform.position += new Vector3(0f, Time.deltaTime*3, 0f);
            }
            else if (transform.position.y > 4.4f)
            {
                smm.moveSlider(5f);
                transform.position += new Vector3(0f, -Time.deltaTime*3, 0f);
                go.transform.position += new Vector3(0f, -Time.deltaTime*3, 0f);
                volando = false;
            }
            else if (transform.position.y > 2f)
            {
                transform.position += new Vector3(0f, -Time.deltaTime*4.5f, 0f);
                go.transform.position += new Vector3(0f, -Time.deltaTime*4.5f, 0f);
            }
            else
            {
                pegarSalto = false;
                volando = true;
            }
        }
        else
        {
            transform.position = _startPosition + new Vector3(0.0f, Mathf.Sin(Time.time * 3) * 0.25f, 0.0f);
            go.transform.position = go_sp + new Vector3(0.0f, Mathf.Sin(Time.time * 3) * 0.25f, 0.0f);
        }
    }
    public void saltar()
    {
        pegarSalto = true;
    }
}
