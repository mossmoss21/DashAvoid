using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bullet_F : MonoBehaviour
{
    // オブジェクト達を呼ぶ
    public GameObject Player; 

    public float speed = 3.0f;  // 弾のスピード
    private int count = 0;      // 弾を消す為のカウント
    private Vector2 vect;       // Playerの座標を保存したい変数
    private Vector2 pos;        // 弾を発射するpos

   void Start()
    {
        Vector2 pos = gameObject.transform.position;    // インスタンス
        Vector2 vect = Player.transform.position;       // ターゲット
    }

    // Update is called once per frame
    void Update()
    {
        /**********************追尾**************************/
        Vector2 pos = gameObject.transform.position;    // インスタンス
        Vector2 vect = Player.transform.position;       // ターゲット
        

        // 弾の移動速度を一定にしてる
        float step = Time.deltaTime * speed;

        // 弾を動かす
        // KOKO
        // ここ
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                                                            target: Player.transform.position,
                                                            maxDistanceDelta: step);
        count += 1;
 
        // 弾の発射感覚
        if (count % 300 == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOver");
        Debug.Log("あたったたたたたたった");
    }
}
