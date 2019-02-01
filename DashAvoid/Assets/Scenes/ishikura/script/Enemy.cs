using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public GameObject Bullet;
    private Renderer targetRenderer;

    // Startメソッドをコルーチンとして呼び出す

    IEnumerator Start() {
        Debug.Log("発射");
        
        while (true){
            targetRenderer = GetComponent<Renderer>();

            if (targetRenderer.isVisible)
            {
                // 弾をエネミーと同じ位置 /角度で作成
                Instantiate(Bullet, transform.position, transform.rotation);
            }
            // 0.05秒待つ
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
