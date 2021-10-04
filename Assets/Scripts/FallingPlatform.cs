using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer render;

    private Vector2 originalPosition;

    [SerializeField]
    private float 
        flashInterval = .25f,
        timeToFall = 4f,
        timeToReset = 8f;

    private void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        render = gameObject.GetComponent<SpriteRenderer>();
        originalPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InvokeRepeating("Flashing", .2f, flashInterval);
            Invoke("DropPlatform", timeToFall);
            Invoke("ResetPosition", timeToReset);
        }
    }

    void Flashing()
    {
        if(render.enabled == true)
        {
            render.enabled = false;
        }
        else
        {
            render.enabled = true;
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
        CancelInvoke("Flashing");
    }

    void ResetPosition()
    {
        render.enabled = false;
        rb.isKinematic = true;
        gameObject.transform.position = originalPosition;
        render.enabled = true;
    }

}
