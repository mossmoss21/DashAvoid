using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bullet_T : MonoBehaviour {
    private int count = 0;      // 弾のカウント
    //private float speed = 3.0f;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1.0f);
        Vector2 Player;
    }

    // Update is called once per frame
    void Update()
    {
        //追尾
        GameObject player = GameObject.Find("Player");
        float speed = 3.0f;
        float step = Time.deltaTime * speed;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.x, Player.y), step);

        count += 1;

        // 弾の発射感覚
        if (count % 400 == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOver");
        //Debug.Log("あたったたたたたたった");

    }
}
