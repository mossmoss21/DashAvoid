using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    //判定
    private bool isGround;         // 地面に接しているか
    private bool isCeiling;        // 天井に接している

    //移動
    private float runSpeed;        // プレイヤーの速度(増減)
    private float defaultRunSpeed; // プレイヤーのデフォルトのスピード

    //ジャンプ
    private bool isJumpFlg;        // ジャンプしているか
    private bool twoJumpFlg;       // 二段ジャンプしているか
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

        //判定
        isGround = false;
        isCeiling = false;

        //移動
        //runSpeed = 0.02f;
        runSpeed = 0.00f;
        defaultRunSpeed = runSpeed;

        //ジャンプ
        isJumpFlg = false;
        twoJumpFlg = false;
        jumpPower = 150.0f;
        jumpCnt = 0.0f;
    }

    /**********************************
    * 
    * 更新
    * 
    **********************************/
    void Update()
    {
        //debug
        Debug.Log("地面と接しているか" + isGround);
        Debug.Log("天井と接しているか" + isCeiling);
        //Debug.Log("ジャンプカウント" + jumpCnt);


        //状態管理(判定)
        StateManagement();

        //移動
        Move();

        //ジャンプ
        Jump();

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

        //天井との当たり判定
        //プレイヤーの上が layer="Block"
        isCeiling = Physics2D.Raycast(
            transform.position, Vector2.up,
            0.45f, 1 << LayerMask.NameToLayer("Block"));
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
        if (Input.GetKey(KeyCode.Space))
        {
            isJumpFlg = true;
            jumpCnt += Time.deltaTime;
            Vector3 pos = transform.position;

            if (jumpCnt < 0.4f && !isCeiling)
                pos.y += 0.1f;// initVelocity * elapsedTime + gravity * Mathf.Pow(jumpCnt,2f)/ 2;

            transform.position = pos;
        }

        if (isGround)
        {
            isJumpFlg = false;
            jumpCnt = 0f;
        }
    }

    /*
     *  ジャンプパワーから重力を引き続ける
     */

}