using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    //判定
    private bool isGround;         // 地面に接しているか
    private bool isCeiling;        // 天井に接している
    private bool isTouchWallLeft;  // 右の壁に接しているか
    private bool isTouchWallRight; // 左の壁に接しているか


    //移動
    private float runSpeed;        // プレイヤーの速度(増減)
    private float defaultRunSpeed; // プレイヤーのデフォルトのスピード
    private float dash;            // 走る速度
    private float slow;            // 減速時の速度

    //ジャンプ
    private bool isJumpFlg;        // ジャンプしているか
    private bool twoJumpFlg;       // 二段ジャンプしているか
    private float jumpCnt;         // ジャンプの押している長さのカウント
    //private float jumpPower;       // ジャンプ力

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
        isTouchWallLeft = false;
        isTouchWallRight = false;

        //移動
        //defaultRunSpeed = 0.02f;
        defaultRunSpeed = 0.0f;
        runSpeed = defaultRunSpeed;


        //ジャンプ
        isJumpFlg = false;
        twoJumpFlg = false;
        jumpCnt = 0.0f;
        //jumpPower = 150.0f;
    }

    /**********************************
    * 
    * 更新
    * 
    **********************************/
    void Update()
    {
        //debug
        //Debug.Log("地面と接しているか" + isGround);
        //Debug.Log("天井と接しているか" + isCeiling);
        //Debug.Log("ジャンプカウント" + jumpCnt);
        Debug.Log("右壁" + isTouchWallRight);
        Debug.Log("左壁" + isTouchWallLeft);

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

        //壁との当たり判定
        //プレイヤーの右が layer="Block"
        isTouchWallRight = Physics2D.Raycast(
            transform.position, Vector2.right,
            0.31f, 1 << LayerMask.NameToLayer("Block"));

        //プレイヤーの右が layer="Block"
        isTouchWallLeft = Physics2D.Raycast(
            transform.position, Vector2.left,
            0.31f, 1 << LayerMask.NameToLayer("Block"));

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
        if (Input.GetKey(KeyCode.RightArrow) && !isTouchWallRight)
        {
            runSpeed = 0.04f;
        }
        //← 減速
        if (Input.GetKey(KeyCode.LeftArrow) && !isTouchWallLeft)
        {
            runSpeed = -0.04f;
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
        if (Input.GetKey(KeyCode.Space) && !twoJumpFlg)
        {
            isJumpFlg = true;
            jumpCnt += Time.deltaTime;
            Vector3 pos = transform.position;

            if (jumpCnt < 0.5f && !isCeiling)
            {
                pos.y += 0.1f;
            }

            transform.position = pos;
        }

        //二段ジャンプ
        if (!isGround && !twoJumpFlg && Input.GetKeyUp(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                twoJumpFlg = true;
            }
        }

        //接地
        if (isGround)
        {
            isJumpFlg = false;
            jumpCnt = 0f;
            twoJumpFlg = false;
        }

        //接天
        if (isCeiling)
        {
            jumpCnt = 0.5f;
        }
    }

    /*
     *  ジャンプパワーから重力を引き続ける
     */

}