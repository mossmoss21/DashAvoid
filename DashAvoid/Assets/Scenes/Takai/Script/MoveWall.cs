using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //移動
        transform.position += new Vector3(0.01f, 0f, 0);

    }

    //当たったらシーンをGAMEOVERへ
    private void OnTriggerEnter2D(Collider2D collision)
    //function OnTriggerEnter2D(col:Collider2D)
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("Player Deth");
    }

}
