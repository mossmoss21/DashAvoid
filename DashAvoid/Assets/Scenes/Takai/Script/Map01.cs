using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Map01 : MonoBehaviour {

    public float startX;
    public float startY;
    public float massWidth;
    public float massHeighth;

    string[] stage =
    {
"bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb",// 1行
"nooooooooooooooooooooooooooooooooboooooooboooooooooooooooooooooooooooooooooooooooooooooboooooooooooboooooooooooobbbbb",// 2
"noooooooooooooooooooooooooooooooobooooocoboooooooooooooooooooooooooooooooooooooooooocooboooooooooooboooooooooooobbbbb",// 3
"nooooooooooooooooocoooooooooooooobooooooobooooooooooooooooooooooooooooooooooooooooooooobooooooooooobooooooooooooobbbb",// 4
"nooooooooooooooooooooooooooooooooboooobbbbooooooooooooooooooooooooooooooooooooooooooooooooooooooooobooooooooooooobbbb",// 5
"nooooooooooooooooooobbbbbbbbooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooobooocooooooooooooo",// 6
"nooooooooooooooooooooooooooooooooooooooooooooooooooobbbbbbboooooooobbbbbbbbbbbbbbbboooooooooooooooobooooooooooooooooo",// 7
"nooooooooooooooooooooooooooocoooobbooooooooooooooooooooooobbooooocooooooooooooooooooooooooooooooooobooooooooooooooooo",// 8
"nooooooooooooooobooooooooooooooooboooooooooooooooooooooooobbbooooooooooooooooooooooooooooooooooooooooooooooooooooooob",// 9
"noooooobbbbboooobboooooobbbbbbbooboooooooooooooobbbbbooooobbbboooooooooooooooooooooooobbbbbbbbbbooooooobbbbbooooobbbb",// 10
"nooooooooooooooobbbooooooooooooooboooooooooooooobbbbbooooobbbbboooooooooooooooooooooobbbbbboooooooooooobbbbboooobbbbb",// 11
"nooooooooooooocobbbbooooooooooooobooooooooooooobbbbbbboocobbbbbboooooooooooooooooooobbbbbboooocoooooooobbbbboocobbbbb",// 12
"nooooooooooooooobbbbboooooooooooobooooooooooooobbbbbbboooobbbbbbboooooooooooooooooobbbbbbbboooooooooooobbbbboooobbbbb",// 13
"bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" // 14
    };

	// Use this for initialization
	void Start () {

        GameObject Block = (GameObject)Resources.Load("Prefabs/pBlock");
        GameObject Needle = (GameObject)Resources.Load("Prefabs/pNeedle");
        GameObject Coin = (GameObject)Resources.Load("Prefabs/pCoin");

        for (int i = 0; i < stage.GetLength(0); i++)
        {
            for (int j = 0; j < stage[i].Length; j++)
            {
                if (stage[i].Substring(j, 1) == "b")
                {
                    Instantiate(Block, new Vector3(startX + j * massWidth, startY - i * massHeighth, 0.0f), Quaternion.identity);
                }
                if (stage[i].Substring(j, 1) == "c")
                {
                    Instantiate(Coin, new Vector3(startX + j * massWidth, startY - i * massHeighth, 0.0f), Quaternion.identity);
                }
                if (stage[i].Substring(j, 1) == "n")
                {
                    Instantiate(Needle, new Vector3(startX + j * massWidth, startY - i * massHeighth, 0.0f), Quaternion.identity);
                }
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
