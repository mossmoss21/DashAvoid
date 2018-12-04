using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool isGameOver;       //ゲームオーバー判定フラグ

    private bool isGrounded;       //地面に接しているか
    private bool possibleFlash;   //フラッシュ出来るかのフラグ
    private float idouSpeed;      //移動スピード
    private float jumpPower;      //ジャンプ力

    private float attackCount;    //アタックカウント
    private bool possibleAttack;  //アタック可能フラグ
    private const float ATTACK_INTERVAL = 0.5f; //アタックのインターバル定数


	// Use this for initialization
	void Start () {
        isGameOver = false;
        isGrounded = false;
        possibleFlash = false;
        //idouSpeed = 0.0f;
        //jumpPower = 0.0f;
        attackCount = 0.0f;
        possibleAttack = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(attackCount >= ATTACK_INTERVAL)
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
        isGrounded = Physics2D.Raycast(
             transform.position, Vector2.down,
             1f, 1 << LayerMask.NameToLayer("Block"));

        //フラッシュオブジェクト当たり判定
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        //障害物に接触
        if(other.gameObject.tag == "shougai")
        {
            isGameOver = true;
        }
    }

}
