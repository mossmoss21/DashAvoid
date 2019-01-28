using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_S : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        int var;
        var = Random.Range(-10, 10);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1.0f);
    }
    // Update is called once per frame
    void Update()
    {
        //velocity.x -= speed;

        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3.0f);

        GameObject player = GameObject.Find("Player");
        float speed = 3.0f;
        float step = Time.deltaTime * speed;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);   //自分を消去する
    }

}
