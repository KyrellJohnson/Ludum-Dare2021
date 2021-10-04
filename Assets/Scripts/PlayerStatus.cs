using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private bool isHit = false;

    [SerializeField]
    private Transform[] spawnPoints;
    CameraSwitchHandler cameraSwitch;
    Animator anim;

    private void Awake()
    {
        cameraSwitch  = GameObject.Find("CameraHandler").GetComponent<CameraSwitchHandler>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    public void setHit(bool hit)
    {
        isHit = hit;

        if(isHit == true)
        {
            anim.SetBool("wasHit", true);
            Invoke("resetPlayer", .6f);
        }

    }

    void resetPlayer()
    {
        setRespawn();
        anim.SetBool("wasHit", false);
        setHit(false);
        
    }

    public bool getHit()
    {
        return isHit;
    }


    public void setRespawn()
    {
        int levelIndex = cameraSwitch.GetCurrentCamera();

        gameObject.transform.position = spawnPoints[levelIndex].transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "LevelSwitch")
        {
            switch (collision.name)
            {
                case "Level1Start":
                    // Clear all cams
                    cameraSwitch.clearAllCams();
                    //set priority for cam1
                    cameraSwitch.SwitchToCamera(0);
                    break;

                case "Level2Start":
                    // Clear all cams
                    cameraSwitch.clearAllCams();
                    //set priority for cam1
                    cameraSwitch.SwitchToCamera(1);
                    break;

                default:
                    cameraSwitch.clearAllCams();
                    cameraSwitch.SwitchToCamera(0);
                    break;
            }


        }
         
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingPlatform" && anim.GetBool("isGrounded") == true)
        {
            transform.parent = collision.gameObject.transform;
        }else
        {
            transform.parent = GameObject.Find("---Player---").transform;
        }
    }

}
