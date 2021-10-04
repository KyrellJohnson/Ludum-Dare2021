using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerStatus : MonoBehaviour
{
    private bool isHit = false;
    public AudioSource deathSound;
    [SerializeField]
    private Transform[] spawnPoints;
    CameraSwitchHandler cameraSwitch;
    Animator anim;
    public Text deathCount;


    public CanvasGroup endgame;
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
            deathSound.Play();
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
        int death = Int32.Parse(deathCount.text);
        death++;
        deathCount.text = death.ToString();
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
                case "Level3Start":
                    // Clear all cams
                    cameraSwitch.clearAllCams();
                    //set priority for cam1
                    cameraSwitch.SwitchToCamera(2);
                    break;
                case "Level4Start":
                    // Clear all cams
                    cameraSwitch.clearAllCams();
                    //set priority for cam1
                    cameraSwitch.SwitchToCamera(3);
                    break;
                case "Level5Start":
                    // Clear all cams
                    cameraSwitch.clearAllCams();
                    //set priority for cam1
                    cameraSwitch.SwitchToCamera(4);
                    break;

                case "Level6Start":
                    // Clear all cams
                    cameraSwitch.clearAllCams();
                    //set priority for cam1
                    cameraSwitch.SwitchToCamera(5);
                    Invoke("EndGame", 1f);
                    break;
                default:
                    cameraSwitch.clearAllCams();
                    cameraSwitch.SwitchToCamera(0);
                    break;
            }


        }
         
    }

    void EndGame()
    {
        endgame.alpha = 2;
        endgame.blocksRaycasts = true;
        endgame.interactable = true;
        Time.timeScale = 0;
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
