using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {
    public GameObject camera;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(camera.transform.position.x,0,0);
        Debug.Log(camera.transform.position.x);
	}
}
