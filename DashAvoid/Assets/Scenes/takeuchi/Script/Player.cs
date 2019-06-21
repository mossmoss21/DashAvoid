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

    //スキル
    private float defaultSkillCT;   // スキルのクールタイム初期化用
    private float skillCT;          // スキルのクールタイムカウント用
    private float skillMoveRange;   // スキルの移動距離
    Vector2 force;                  // AddForceで使用

    private Collider2D _collider;

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
        gravity = 2.5f;

        _rigidbody2D = GetComponent<Rigidbody2D>();

        // スキル
        defaultSkillCT = 10.0f;
        skillCT = defaultSkillCT;
        skillMoveRange = 10.0f;

        force = new Vector2(0.0f, 0.0f);

        _collider = GetComponent<Collider2D>();
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
        }
        else
        {
            _rigidbody2D.gravityScale = gravity;
            isJumpFlg = false;
            jumpMaxCnt = 0.0f;
            isCeiling = false;
        }

        // スキル
        if (skillCT <= 0)
        {
            Skill();
            Debug.Log("CT終了");
        }
        else if(skillCT > 0)
        {
            _collider.isTrigger = false;
            force = new Vector2(0.0f, 0.0f);
            skillCT -= Time.deltaTime * 5;
        }
        Debug.Log(_collider.isTrigger);
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
    /**********************************
    * 
    * スキル
    * 
    **********************************/
    void Skill()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.RightArrow) && isTouchWallRight == false)
            {
                //_collider.isTrigger = true;
                force = new Vector2(skillMoveRange, 0);
                skillCT = defaultSkillCT;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && isTouchWallLeft == false)
            {
                //_collider.isTrigger = true;
                force = new Vector2(-skillMoveRange, 0);
                skillCT = defaultSkillCT;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && isCeiling == false)
            {
                //_collider.isTrigger = true;
                force = new Vector2(0,skillMoveRange);
                skillCT = defaultSkillCT;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && isGround == false)
            {
                //_collider.isTrigger = true;
                force = new Vector2(0,-skillMoveRange);
                skillCT = defaultSkillCT;
            }
        }
        _rigidbody2D.AddForce(force,ForceMode2D.Impulse);
    }
}

//当たり判定無くなってるの一瞬では(?)

//yield return new WaitForSeconds(1.0f);
//_collider.isTrigger = false;