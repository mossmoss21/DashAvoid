using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    int ScoreCnt = 0;
    void Start() {
    }
    void Update(){
        GetComponent<Text>().text =""+ ScoreCnt;
    }
    void ScoreSum(){
        ScoreCnt += 1000;
    }

}
