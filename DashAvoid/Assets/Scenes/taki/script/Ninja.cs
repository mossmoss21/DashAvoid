using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    //  public float move;
    public float dash;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dash = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.1f, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;

            dash = 1f;
            //   move = 1f;

        }
     

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.1f, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
            //    move = 1f;
            dash = 1f;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 300.0f, 0));
        }

        GetComponent<Animator>().SetFloat("dash", dash);
        // GetComponent<Animator>().SetFloat("move", move);
     
    }
}
