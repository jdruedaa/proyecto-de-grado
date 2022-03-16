using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgtrasform : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x <= -69f)
        {
            transform.position = new Vector3(80.6f, 10.59f, 0f);
        }
        transform.position += new Vector3(-6f * Time.deltaTime, 0, 0);
    }
}
