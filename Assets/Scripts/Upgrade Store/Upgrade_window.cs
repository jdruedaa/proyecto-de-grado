using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_window : MonoBehaviour
{

    public string name;
    public int[] precios;
    public int mejoraRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Store.preciosAct = precios;
        if(Store.upgradeScreen){
            Store.actualId = mejoraRef;
            Store.preciosAct = precios;
            Store.texts[0].text = "Upgrade " + name;
            int mejoraActualCel = GameManager.mejoras[0];
            if(mejoraActualCel >= 3)
            {
                Store.texts[1].text = "Sold out";
            }
            else
            {
                Store.texts[1].text = "$" + precios[mejoraActualCel];
            }
            Store.upgradeScreen = !Store.upgradeScreen;
        }
    }
}
