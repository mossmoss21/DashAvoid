using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("ScoreText").SendMessage("ScoreSum");
        Destroy(this.gameObject);   //自分を消去する
    }
}
