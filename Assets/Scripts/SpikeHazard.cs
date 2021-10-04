using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHazard : MonoBehaviour
{
    PlayerStatus player;
    Vector2 originalPosition;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerStatus>();
        originalPosition = new Vector2(transform.position.x, transform.position.y);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.setHit(true);
            //gameObject.transform.position = originalPosition;


        }
    }

}

