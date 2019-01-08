﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;

    public bool isBossFlg;        // 0:通常時 1:ボス時
    public bool isGameOver;       //ゲームオーバー判定フラグ
    public bool isDead;           //死亡判定フラグ

    private float runSpeed;        // プレイヤーの速度
    private float defaultRunSpeed; // プレイヤーのデフォルトのスピード

    private float jumpPower;      //ジャンプ力
    private bool isGrounded;      //地面に接しているか
    private int jmpCnt;           //ジャンプの押している長さのカウント

    private float attackCount;    //アタックカウント
    private bool possibleAttack;  //アタック可能フラグ
    private const float ATTACK_INTERVAL = 0.5f; //アタックのインターバル定数

    private bool possibleFlash;   //フラッシュ出来るかのフラグ

    // Use this for initialization
    void Start () {
        instance = this;
        isBossFlg = false;
        isGameOver = false;
        isGrounded = false;
        possibleFlash = false;

        jumpPower = 450.0f;
        attackCount = 0.0f;
        possibleAttack = true;
        isDead = false;
        runSpeed = 0.03f;
        defaultRunSpeed = runSpeed;

    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("スピード" + runSpeed);
        //Debug.Log("フラッシュ可能" + possibleFlash);
        Debug.Log("地面接しているか" + isGrounded);

        //移動
        move();

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
             1.3f, 1 << LayerMask.NameToLayer("Block"));

        //フラッシュオブジェクト当たり判定
        //プレイヤーの右端が layer="flash"のオブジェクトと接触しているならTrue
        possibleFlash = Physics2D.Raycast(
             transform.position, Vector2.right,
             1f, 1 << LayerMask.NameToLayer("flash"));

        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
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

    // 移動 
    void move(){

        // 通常時の動き
        if(isBossFlg == false){

            runSpeed = defaultRunSpeed;

            //→ 加速
            if (Input.GetKey(KeyCode.RightArrow))
            {
                runSpeed = 0.06f;
            }

            //← 減速
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                runSpeed = 0.0f;
            }

        }

        // ボス時の動き
        else{
            //→ 右
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0.3f, 0, 0);
            }
            //← 左
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(0.3f, 0, 0);
            }
        }

        //移動の計算
        transform.position += new Vector3(runSpeed, 0, 0);

    }

    // 攻撃
    void attack(){
        //敵を攻撃
        //弾を消せる
    }

    // ジャンプ
    void jump(){

        //押してる長さでジャンプ力変化
        //三段階か四段階でポイントがあって
        //そこの時点でSpaceキーが押されているか判断
        //離されていたら落下(RigidBody)

        //ジャンプ
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpPower, 0));

        //浮いてるブロックとの当たり判定
        //「Edit」->「Project Settings」->「Physics」を選択するとInspectorに「PhysicsManager」

    }

    // フラッシュ
    void flashAction(){
        //switchでオブジェクトによって動作を分ける
    }

}