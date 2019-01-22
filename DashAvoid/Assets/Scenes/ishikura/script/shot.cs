using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {
    GameObject target;
    Vector3 velocity;

    float rad;
    float deg;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("player");
        velocity= Vector3.zero;
        rad = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        float dx =target.transform.position.x - transform.position.x;
            float dy = target.transform.position.y - transform.position.y;
        rad =  Mathf.Atan2(dy,dx);
        deg = rad * Mathf.Rad2Deg;
        transform.position += Vector3.MoveTowards(transform.position,target.transform.position,1f);
	}
}
