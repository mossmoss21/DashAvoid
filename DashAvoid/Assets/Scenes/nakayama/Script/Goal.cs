using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {


    //カウントダウンのテキストの表示の関数
    [SerializeField]
    private Text _textCountdown;

    // Use this for initialization
    void Start () {
        //テキストを非表示にする
        _textCountdown.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //接触したら"ゴール"
    void OnTriggerEnter2D(Collider2D other)
    {
        _textCountdown.gameObject.SetActive(true);      //カウントのテキストが表示する
        _textCountdown.text = "GOOOOOOL";
    }

}
