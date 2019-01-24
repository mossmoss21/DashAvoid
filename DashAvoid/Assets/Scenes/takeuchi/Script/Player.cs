using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private bool isGround;         // 地面に接しているか
    public bool isDead;            //死亡判定フラグ

    private float runSpeed;        // プレイヤーの速度
    private float defaultRunSpeed; // プレイヤーのデフォルトのスピード

    [SerializeField]
    private float jumpPower;       // ジャンプ力
    private float jumpCnt;         // ジャンプの押している長さのカウント
    private bool twoJumpFlg;       // 二段ジャンプしているか

    //ジャンプコード
    private bool isJumpFlg;        // ジャンプしているか
    float gravity;
    float initVelocity;
    float elapsedTime;

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
        twoJumpFlg = false;
        isJumpFlg = false;

        jumpPower = 150.0f;
        //runSpeed = 0.02f;
        runSpeed = 0.00f;
        defaultRunSpeed = runSpeed;

        //ジャンプコード
        gravity = -9.8f;
        initVelocity = 10f;
        elapsedTime = 0f;

    }

    /**********************************
    * 
    * 更新
    * 
    **********************************/
    void Update()
    {
        //debug
        Debug.Log("地面接しているか" + isGround);
        //Debug.Log("ジャンプカウント" + jumpCnt);


        //状態管理
        StateManagement();


        //移動
        Move();

        //ジャンプ
        if (Input.GetKey(KeyCode.Space))
        {
            isJumpFlg = true;
            jumpCnt += Time.deltaTime;
            Vector3 pos = transform.position;

            if(jumpCnt < 0.6f)
            pos.y += 0.1f;// initVelocity * elapsedTime + gravity * Mathf.Pow(jumpCnt,2f)/ 2;

            transform.position = pos;
        }

        if(isGround)
        {
            isJumpFlg = false;
            jumpCnt = 0f;
        }

        /*
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("スペースキーDOWN");
            //時間をカウント
            jumpCnt += 1 * Time.deltaTime;// 1.0f;

            if (isGround)
            {
                Jump();
            }
            else if ( (jumpCnt >= 0.3f && jumpCnt <= 0.5f) && twoJumpFlg == false )
            {
                TwoJump();
            }

        }
        if (isGround)
        {
            jumpCnt = 0;
            twoJumpFlg = false;
            //Debug.Log("地面");
        }
        */

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
             0.55f, 1 << LayerMask.NameToLayer("Block"));
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
            runSpeed = 0.03f;
        }
        //← 減速
        if (Input.GetKey(KeyCode.LeftArrow)){
            runSpeed = -0.02f;
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
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpPower));
            //Debug.Log("ジャンプ");
        //浮いてるブロックとの当たり判定
        //「Edit」->「Project Settings」->「Physics」を選択するとInspectorに「PhysicsManager」
    }

    void TwoJump()
    {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpPower));
            //Debug.Log("二段ジャンプ");
            twoJumpFlg = true;
    }
}