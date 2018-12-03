using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool isBossFlg;   // 0:通常時 1:ボス時
    private bool LeftKeyFlg;  // 0:Down 1:Up
    private bool RightKeyFlg; //0:Down 1:Up

    private int speed;      // プレイヤーの速度

    // Use this for initialization
    void Start () {
        isBossFlg = false;
        LeftKeyFlg = false;
        RightKeyFlg = false;

        speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    // 移動 
    void PlayerMove(){

        // 通常時の動き
        if(isBossFlg == false)
        {
            //常に移動(キーが押されていないなら)
            if(RightKeyFlg == false || LeftKeyFlg == false){
                //transform.position += new Vector3(0.3f, 0, 0);
                transform.position += new Vector3(0.01f, 0, 0);  //debug
            }

            //→ 加速
            if (Input.GetKeyDown(KeyCode.RightArrow)){
                RightKeyFlg = true;
                transform.position += new Vector3(0.3f, 0, 0);
            }

            //← 減速
            if (Input.GetKeyDown(KeyCode.LeftArrow)){
                LeftKeyFlg = true;
                transform.position -= new Vector3(0.3f, 0, 0);
            }

            //キーが離されているならフラグをfalseに
            if (Input.GetKeyUp(KeyCode.RightArrow)){
                RightKeyFlg = false;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow)){
                LeftKeyFlg = false;
            }


            /* _memo
             
             　キーを押している間は自動で移動しないようにしたかった。
              　　　　　↓↓↓
               キーのup/downにしたらキーが押された瞬間の
               一回の処理しかされなくなった。

           */

        }

        // ボス時の動き
        else
        {
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