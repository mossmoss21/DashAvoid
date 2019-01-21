using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private bool isGround;       // 地面に接しているか
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
        isGround = false;
        isDead = false;

        jumpPower = 200.0f;
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
        //Debug.Log("地面接しているか" + isGround);
        //Debug.Log("ジャンプカウント" + jumpCnt);


        //状態管理
        StateManagement();


        //移動
        Move();

        //ジャンプ
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("スペースキーDOWN");
            //時間をカウント
            jumpCnt += 5.0f;

            if (isGround || jumpCnt >= 200 && jumpCnt <= 300)
            {
                Jump();
            }

        }
        if (Input.GetKeyUp(KeyCode.Space) || isGround)
        {
            jumpCnt = 0;
            Debug.Log("地面");
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
        isGround = Physics2D.Raycast(
             transform.position, Vector2.down,
             1.3f, 1 << LayerMask.NameToLayer("Block"));
    }

    /**********************************
    * 
    * 移動
    * 
    **********************************/
    void Move()
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
    void Jump()
    {

        //ジャンプ
        if (jumpCnt <= 200.0f)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpPower));
            Debug.Log("ジャンプ");
        }

        //浮いてるブロックとの当たり判定
        //「Edit」->「Project Settings」->「Physics」を選択するとInspectorに「PhysicsManager」

    }
}