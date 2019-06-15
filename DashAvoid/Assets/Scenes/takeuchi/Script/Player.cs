using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    //判定
    public bool isGround;            // 地面に接しているか
    public bool isCeiling;           // 天井に接している
    private bool isTouchWallLeft;     // 右の壁に接しているか
    private bool isTouchWallRight;    // 左の壁に接しているか

    //移動
    private float runSpeed;          // プレイヤーの速度(増減)
    private float defaultRunSpeed;   // プレイヤーのデフォルトのスピード

    //ジャンプ
    private bool isJumpFlg;                     // ジャンプしているか
    [SerializeField]public float jumpPow;       // ジャンプ力
    private float jumpMaxCnt;                   // スペースを押している時間
    [SerializeField] private float jumpMaxTime;  // スペースを押している間ジャンプする時間
    [SerializeField] private float gravity;     // 重力

    private Rigidbody2D _rigidbody2D;

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
        defaultRunSpeed = 0.0f;
        runSpeed = defaultRunSpeed;

        //ジャンプ
        isJumpFlg = false;
        jumpPow = 8.0f;
        
        jumpMaxCnt = 0.0f;
        jumpMaxTime = 2.0f;
        gravity = 1.8f;

        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    /**********************************
    * 
    * 更新
    * 
    **********************************/
    void Update()
    {
        /*****debug*****/
        //Debug.Log("地面と接しているか" + isGround);
        //Debug.Log("天井と接しているか" + isCeiling);
        //Debug.Log("右壁" + isTouchWallRight);
        //Debug.Log("左壁" + isTouchWallLeft);
        //Debug.Log("ジャンプ中か" + isJumpFlg);

        // 状態管理(判定)
        StateManagement();

        // 移動
        Move();

        // ジャンプ
        if (isGround == true && isJumpFlg == false && Input.GetKeyDown(KeyCode.Space))
        {
            isJumpFlg = true;

            //    AudioManager.Instance.PlaySE("Jump");
        }
        else if (isJumpFlg == true && Input.GetKey(KeyCode.Space))
        {
            Jump();
            Debug.Log("スペース押されている");
        }
        else
        {
            _rigidbody2D.gravityScale = gravity;
            isJumpFlg = false;
            jumpMaxCnt = 0.0f;
            isCeiling = false;
        }

    }

    /**********************************
    * 
    * プレイヤーの状態管理
    * 
    **********************************/
    void StateManagement()
    {

        //壁との当たり判定
        //プレイヤーの右が layer=="Block"
        isTouchWallRight = Physics2D.Raycast(
            transform.position, Vector2.right,
            0.5f, 1 << LayerMask.NameToLayer("Block"));

        //プレイヤーの左が layer=="Block"
        isTouchWallLeft = Physics2D.Raycast(
            transform.position, Vector2.left,
            0.8f, 1 << LayerMask.NameToLayer("Block"));

        /*フラグは移動ができないようにしてるだけなので
         　上から落ちて壁にすれすれで当たると二つとも
           フラグがtrueになってしまう(?)*/
        if(isTouchWallLeft == true && isTouchWallRight == true)
        {
            isTouchWallRight = false;
            isTouchWallLeft = false;
        }

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
        if (Input.GetKey(KeyCode.RightArrow) && isTouchWallRight == false)
        {
            runSpeed = 0.04f;
        }
        //← 減速
        if (Input.GetKey(KeyCode.LeftArrow) && isTouchWallLeft == false)
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
        _rigidbody2D.gravityScale = gravity / 2;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpPow);

        jumpMaxCnt += Time.deltaTime * 5;

        // ジャンプ制限
        if (jumpMaxCnt > jumpMaxTime || isCeiling == true || jumpPow < 0)
        {
            isJumpFlg = false;
        }
    }

}