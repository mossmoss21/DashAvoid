using UnityEngine;
using System.Collections;
public class Player1 : MonoBehaviour
{
    public float speed = 5; // 移動スピード
                            // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); // 右・左
        float y = Input.GetAxisRaw("Vertical");     // 上・下
                                                    // 移動する向きを求めて、スピードをかけたものを代入する
        Vector2 direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
