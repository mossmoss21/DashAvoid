using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSensor : MonoBehaviour {

    private Player _player;

	// Use this for initialization
	void Start () {
        _player = GetComponentInParent<Player>();
	}

    void Update()
    {
        _player.isGround = Physics2D.Raycast(
    transform.position, Vector2.down,
    1.0f, 1 << LayerMask.NameToLayer("Block"));
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Block")
    //    {
    //        _player.isGround = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.tag == "Block")
    //    {
    //        _player.isGround = false;
    //    }
    //}

    // ブロックをまたぐ毎にIN,OUTするのでたまにフラグがfalseになりジャンプができない
}
