using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    bool pausado;
    void Start()
    {
    } 
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(pausado)
                Time.timeScale = 1;
            else
                Time.timeScale = 0;
            pausado = !pausado;
        }
    }
}
