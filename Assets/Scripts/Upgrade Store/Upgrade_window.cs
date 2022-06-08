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
        if(Store.upgradeScreen){
            Store.preciosAct = precios;
            Store.actualId = mejoraRef;
            Store.texts[0].text = "Upgrade " + name;
            int mejoraActualCel = 3;
            if(mejoraRef < 3){
                mejoraActualCel = GameManager.mejoras[mejoraRef];
            } else if(mejoraRef < 5){
                mejoraActualCel = GameManager.consumibles[mejoraRef-3];
            } else{
                //coofee
            }
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
