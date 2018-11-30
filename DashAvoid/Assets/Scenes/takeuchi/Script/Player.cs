using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int isBossFlg;

    // Use this for initialization
    void Start () {
        int isBossFlg = 0;
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
            //→
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0.3f, 0, 0);
            }
            //←(移動速度減少予定)
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