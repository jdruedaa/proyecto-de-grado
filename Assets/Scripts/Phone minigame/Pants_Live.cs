using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pants_Live : MonoBehaviour
{
    public static Pants_Live pants;

    void Awake() 
    {
        if(pants == null){
            DontDestroyOnLoad(this.gameObject);
            pants = this;
        }else{
            Destroy(this.gameObject);
        }

    }
}
