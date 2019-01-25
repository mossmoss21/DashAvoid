using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

    public static Player2 instance;

    public bool isGameOver;       //ゲームオーバー判定フラグ
    public bool isDead;
    private bool isGrounded;       //地面に接しているか
    private bool possibleFlash;   //フラッシュ出来るかのフラグ
    private float idouSpeed;      //移動スピード
    private float jumpPower;      //ジャンプ力

    private float attackCount;    //アタックカウント
    private bool possibleAttack;  //アタック可能フラグ
    private const float ATTACK_INTERVAL = 0.5f; //アタックのインターバル定数

    private float moveSpeed = 0.1f;
    private float defaultMoveSpeed = 0.1f;
	// Use this for initialization
	void Start () {
        instance = this;
        isGameOver = false;
        isGrounded = false;
        possibleFlash = false;
        //idouSpeed = 0.0f;
        //jumpPower = 0.0f;
        attackCount = 0.0f;
        possibleAttack = true;
        isDead = false;
	}
	


	// Update is called once per frame
	void Update () {
        Debug.Log("フラッシュ可能"+possibleFlash);
        Debug.Log("地面接しているか" + isGrounded);


        moveSpeed = defaultMoveSpeed;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(moveSpeed, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-moveSpeed, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0.0f,moveSpeed, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0.0f,-moveSpeed, 0.0f);
        }

        

        if (attackCount >= ATTACK_INTERVAL)
        {
            //攻撃可能状態へ
            possibleAttack = true;
        }
        else
        {
            //秒数加算
            attackCount += Time.deltaTime;
        }

        //地面当たり判定
        //プレイヤーの下が layer="Block"
        isGrounded = Physics2D.Raycast(
             transform.position, Vector2.down,
             1f, 1 << LayerMask.NameToLayer("Block"));

        //フラッシュオブジェクト当たり判定
        //プレイヤーの右端が layer="flash"のオブジェクトと接触しているならTrue
        possibleFlash = Physics2D.Raycast(
             transform.position, Vector2.right,
             1f, 1 << LayerMask.NameToLayer("flash"));

        //ジャンプ
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                jump();
            }
        }

        //攻撃
        if (Input.GetKey(KeyCode.X))
        {
            if (possibleAttack)
            {
                attack();
            }
        }

        //フラッシュ
        if (Input.GetKey(KeyCode.C))
        {
            if (possibleFlash)
            {
                flashAction();
            }
        }


    }
    //ジャンプ関数
    void jump()
    {

    }

    //攻撃関数
    void attack()
    {

    }

    //フラッシュ判定関数
    void flashAction()
    {

    }


}
