using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool isBossFlg;   // 0:通常時 1:ボス時
    private bool leftKeyFlg;  // 0:Down 1:Up
    private bool rightKeyFlg; //0:Down 1:Up

    private float runSpeed;      // プレイヤーの速度
    private float defaultRunSpeed; // プレイヤーのデフォルトのスピード

    // Use this for initialization
    void Start () {
        isBossFlg = false;
        leftKeyFlg = false;
        rightKeyFlg = false;

        runSpeed = 0.3f;
        defaultRunSpeed = runSpeed;

    }
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
        Debug.Log("スピード"+runSpeed);
	}

    // 移動 
    void PlayerMove(){

        // 通常時の動き
        if(isBossFlg == false){

            runSpeed = defaultRunSpeed;

            //→ 加速
            if (Input.GetKey(KeyCode.RightArrow))
            {
                runSpeed = 1.0f;
            }

            //← 減速
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                runSpeed = 0.0f;
            }

            playerRun();


        }

        // ボス時の動き
        else{
            //→
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0.3f, 0, 0);
            }
            //←
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(0.3f, 0, 0);
            }
        }


    }

    void playerRun(){
        transform.position += new Vector3(runSpeed, 0, 0);
    }

    // 攻撃
    void PlayerAttack(){
        //Xキー
        //敵を攻撃
        //弾を消せる
    }

    // ジャンプ
    void Jump(){
        //スペースキー or Zキー
        //押してる長さでジャンプ力変化
        //三段階か四段階でポイントがあって
        //そこの時点でSpaceキーが押されているか判断
        //離されていたら落下(RigidBody)

    }

    // フラッシュ
    void Frash(){
        //Cキー
        //押したときにフラッシュ可動範囲ならフラッシュアクション
        //switchでオブジェクトによって動作を分ける
    }

}