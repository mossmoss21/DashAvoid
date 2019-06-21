using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet_T : MonoBehaviour {

    private int count = 0;      // 弾のカウント
    //public GameObject Enemy;   
    //public float shotSpeed;

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
        GameObject player = GameObject.Find("Player");
        float speed = 3.0f;
        float step = Time.deltaTime * speed;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);

        count += 1;

        // １００フレームごとにEnemyShot()メソッドを実行する。
        if (count % 200 == 0)
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        //SceneManager.LoadScene("GameOver");
        Debug.Log("あたったたたたたたった");
    }
}
