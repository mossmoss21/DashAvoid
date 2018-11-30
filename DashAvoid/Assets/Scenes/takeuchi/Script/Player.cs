using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int isBossFlg;  // 0:通常時 1:ボス時
    private int speed;      // プレイヤーの速度

    // Use this for initialization
    void Start () {
        isBossFlg = 0;
        speed = 0;

	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    // 移動 
    void PlayerMove(){

        // 通常時の動き
        if(isBossFlg == 0)
        {
            //常に移動
            //transform.position += new Vector3(0.3f, 0, 0);
            transform.position += new Vector3(0.01f, 0, 0);  //debug

            //→ 加速
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0.3f, 0, 0);
            }

            //← 減速
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(0.3f, 0, 0);
            }
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