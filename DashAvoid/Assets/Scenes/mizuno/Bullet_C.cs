using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_C : MonoBehaviour {

    [SerializeField]
    public int LRFlag ;


    // Use this for initialization
    void Start () {
        
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 6.0f , 0);
    }

    // Update is called once per frame
    void Update () {
       GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0f, 0f, 0.3f * LRFlag) * GetComponent<Rigidbody2D>().velocity;

    }
}
