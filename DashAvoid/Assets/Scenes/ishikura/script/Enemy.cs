using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public GameObject Bullet;

    // Startメソッドをコルーチンとして呼び出す
    IEnumerator Start() {
        Debug.Log("発射");

        while (true){
            // 弾をエネミーと同じ位置 /角度で作成
            Instantiate(Bullet, transform.position, transform.rotation);
            // 0.05秒待つ
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
