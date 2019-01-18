using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // 移動スピード
    public float speed = 5;

    // PlayerBulletプレハブ
    public GameObject bullet;

    // Startメソッドをコルーチンとして呼び出す
    IEnumerator Start()
    {
        while (true)
        {
            // 弾をエネミーと同じ位置 /角度で作成
            Instantiate(bullet, transform.position, transform.rotation);
            // 0.05秒待つ
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
