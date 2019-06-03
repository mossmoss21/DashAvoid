using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    private static int coinCounts;

    public static int GetCoin()
    {
        return coinCounts;
    }
    // Use this for initialization
    void Start () {
        coinCounts = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("ScoreText").SendMessage("ScoreSum");
        coinCounts++;
        Destroy(this.gameObject);   //自分を消去する
    }

}
