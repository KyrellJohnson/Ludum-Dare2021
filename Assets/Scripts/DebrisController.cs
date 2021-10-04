using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisController : MonoBehaviour
{

    float randomRotate;
    private void Awake()
    {

        randomRotate = Random.Range(-1f, 1f);

    }

    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.Rotate(new Vector3(0, 0, randomRotate));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }

}
