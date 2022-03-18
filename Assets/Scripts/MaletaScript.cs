using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaletaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, -0.1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
