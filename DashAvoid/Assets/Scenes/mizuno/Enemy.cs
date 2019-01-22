using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {
    public GameObject Bullet;
    public GameObject Player;
    public Transform Target;
    private int count;
    private float x, z;

    private float bufAngle;
    // Use this for initialization
    /*
    IEnumerator Start() {
        while (true)
        {
            
            Instantiate(Bullet, transform.position, transform.rotation);
            
            yield return new WaitForSeconds(1.0f);
        }
    }
    */
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(new Vector3(0, 0, 2));
        bufAngle = Mathf.Atan2(Player.transform.position.x - transform.position.x , Player.transform.position.z - transform.position.z);
        x = Mathf.Cos(bufAngle);
        z = Mathf.Sin(bufAngle);
        //transform.rotation = ;
        //transform.LookAt( new Vector3(Player.transform.position.x, Player.transform.position.y, 0));
        //this.transform.LookAt(Target.position);
        count++;
        if(count > 60)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            count = 0;
        }
    }
}
