using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet_S : MonoBehaviour {

    [SerializeField]
    float speed;

    //移動ベクトル
    Vector3 velocity;

    public GameObject player;


    // Use this for initialization

    void Start(){
        int var;
        var = Random.Range(-10, 10);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1.0f);
    }
    // Update is called once per frame
    void Update () {
        //velocity.x -= speed;

        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3.0f);
        
        GameObject player = GameObject.Find("Player");
        float speed = 3.0f;
        float step = Time.deltaTime * speed;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }
    void OnTriggerEnter2D(Collider2D other){
        Destroy(this.gameObject);
        Debug.Log("破壊されているはず");
    }
}