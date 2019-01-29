using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_N : MonoBehaviour {

    private int count = 0;      // 弾のカウント
    //public GameObject Enemy;      // 
    //public float shotSpeed;


    // Use this for initialization
    void Start()
    {
        int var;
        //int count = 0;      // 弾のカウント
        //var = Random.Range(-10, 10);

        GetComponent<Rigidbody2D>().velocity = new Vector2(-13, 0.0001f);
    }

    // Update is called once per frame
     void Update()
    {
       
        GameObject player = GameObject.Find("Player");

        count += 1;

        // １００フレームごとにEnemyShot()メソッドを実行する。
        if (count % 300 == 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        Debug.Log("破壊されているはず");
    }
}
