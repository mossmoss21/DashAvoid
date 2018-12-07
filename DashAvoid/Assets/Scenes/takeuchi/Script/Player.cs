using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool isBossFlg;   // 0:通常時 1:ボス時

    private float runSpeed;        // プレイヤーの速度
    private float defaultRunSpeed; // プレイヤーのデフォルトのスピード

    // Use this for initialization
    void Start () {
        isBossFlg = false;

        runSpeed = 0.3f;
        defaultRunSpeed = runSpeed;

    }
	
	// Update is called once per frame
	void Update () {
        playerMove();

        Debug.Log("スピード"+runSpeed);     //debug
	}

    // 移動 
    void playerMove(){

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

            playerRun();    // スピードの加算

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


    }

    //スピードを座標に加算する
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