using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // 移動スピード
    public float speed = 5;

    // PlayerBulletプレハブ
    public GameObject bullet;

    // Startメソッドをコルーチンとして呼び出す
    IEnumerator Start(){

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
        /*
            Vector2 Aim(GameObject Enemy, GameObject Player, float angleOffset)
            {
                Vector3 posDif = Player.transform.position - Enemy.transform.position;
                float angle = Mathf.Atan2(posDif.y, posDif.x) * Mathf.Rad2Deg;
                Vector3 euler = new Vector3(0, 0, angle + angleOffset);

                Enemy.transform.rotation = Quaternion.Euler(euler);

                return posDif.normalized;
            }
        */
    }
}
