using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bottun1 : MonoBehaviour {

	// Use this for initialization
	void Start () {


        Selectable sel = GetComponent<Selectable>();
        sel.Select();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Select()
    {
        SceneManager.LoadScene("Map01");
    }
}
