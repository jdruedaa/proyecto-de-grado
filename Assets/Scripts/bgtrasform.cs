using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgtrasform : MonoBehaviour
{
    public GameObject bus;

    public float altura;
    void FixedUpdate()
    {
        if(!bus.GetComponent<UpAndDown>().estaFrenado) {
            if (transform.position.x <= -69f)
            {
                transform.position = new Vector3(80.6f, altura, 0f);
            }
            transform.position += new Vector3(-6f * Time.deltaTime, 0, 0);
        }
    }
}
