using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    //プレイヤーの移動 
    void PlayerMove()
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
}



