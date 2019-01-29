using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    // 移動スピード
   // public float speed = 5;

    // PlayerBulletプレハブ
    public GameObject Bullet;
    public Transform target;    // 追いかける対象

    //private int count = 0;      // 弾のカウント

    // Startメソッドをコルーチンとして呼び出す
    IEnumerator Start()
    {

        while (true)
        {
            // 弾をエネミーと同じ位置 /角度で作成
            Instantiate(Bullet, transform.position, transform.rotation);
            // 0.05秒待つ
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 対象に少しずつ向く
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(target.position - transform.position), 0.009f);
        /*
        count += 1;

        // １００フレームごとにEnemyShot()メソッドを実行する。
        if (count % 100 == 0)
        {
            Bullet();
        }
        */
    }
}
