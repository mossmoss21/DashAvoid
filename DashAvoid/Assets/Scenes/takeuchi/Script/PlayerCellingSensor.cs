using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCeilingSensor : MonoBehaviour {

    private Player _player;

    // Use this for initialization
    void Start()
    {
        _player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            _player.isCeiling = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            _player.isCeiling = false;
        }
    }

}
