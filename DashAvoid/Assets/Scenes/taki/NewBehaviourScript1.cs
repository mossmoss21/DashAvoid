﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x <= 69.55)
        {

            transform.position += new Vector3(0.01f, 0f, 0);

        }
	}
}
