using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private bool isGrounded;       // 地面に接しているか
    public bool isDead;            //死亡判定フラグ

    private float runSpeed;        // プレイヤーの速度
    private float defaultRunSpeed; // プレイヤーのデフォルトのスピード

    private float jumpPower;       // ジャンプ力
    private float jumpCnt;         // ジャンプの押している長さのカウント

    /**********************************
    * 
    * 初期化
    * 
    **********************************/
    void Start()
    {
        instance = this;
        isGrounded = false;
        isDead = false;

        jumpPower = 150.0f;
        runSpeed = 0.03f;
        defaultRunSpeed = runSpeed;

    }

    /**********************************
    * 
    * 更新
    * 
    **********************************/
    void Update()
    {
        //debug
        Debug.Log("地面接しているか" + isGrounded);
        //Debug.Log("ジャンプカウント" + jumpCnt);

        //状態管理
        StateManagement();

        //移動
        move();

        //ジャンプ
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("スペースキーDOWN");
            //時間をカウント
            jumpCnt += (1 * Time.deltaTime);

            if (isGrounded)
            {
                jump();
            }

        }
        if (Input.GetKeyUp(KeyCode.Space) || isGrounded)
        {
            jumpCnt = 0;
            Debug.Log("スペースキーUP");
        }

    }

    /**********************************
    * 
    * プレイヤーの状態管理
    * 
    **********************************/
    void StateManagement()
    {
        //地面当たり判定
        //プレイヤーの下が layer="Block"
        isGrounded = Physics2D.Raycast(
             transform.position, Vector2.down,
             1.3f, 1 << LayerMask.NameToLayer("Block"));
    }

    /**********************************
    * 
    * 移動
    * 
    **********************************/
    void move()
    {
        runSpeed = defaultRunSpeed;

        //→ 加速
        if (Input.GetKey(KeyCode.RightArrow)){
            runSpeed = 0.06f;
        }
        //← 減速
        if (Input.GetKey(KeyCode.LeftArrow)){
            runSpeed = 0.0f;
        }

        //移動の計算
        transform.position += new Vector3(runSpeed, 0, 0);

    }

    /**********************************
    * 
    * ジャンプ
    * 
    **********************************/
    void jump()
    {

        //ジャンプ
        if (jumpCnt <= 1.0f)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpPower));
            Debug.Log("ジャンプ");
        }

        //浮いてるブロックとの当たり判定
        //「Edit」->「Project Settings」->「Physics」を選択するとInspectorに「PhysicsManager」

    }
}