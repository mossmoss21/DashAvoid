using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Rigibody2Dコンポーネントの取得
        //rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(0.1f, 0, 0);
        }
        /*
        if (Input.GetKey(KeyCode.UPArrow))
        {
            transform.position -= new Vector3(0.1f, 0, 0);
        }
        */
    }
}