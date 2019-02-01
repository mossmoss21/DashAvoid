using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet_N : MonoBehaviour {

    private int count = 0;      // 弾のカウント

    // Use this for initialization
    void Start() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-13, 0.001f);
    }

    // Update is called once per frame
    void Update() {
        GameObject player = GameObject.Find("Player");

        count += 1; // 弾のカウント

        // 弾の発射感覚
        if (count % 500 == 0){
            Destroy(this.gameObject);
        } 
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOver");
        Debug.Log("あたったたたたたたった");
    }
}
