using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitchHandler : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera[] cameras;

    private CinemachineBasicMultiChannelPerlin[] cameraNoise;

    private void Start()
    {
        //set all level cams to 0 priority
        for(int i = 0; i < cameras.Length; i++)
        {
            if(cameras[i].name != "CM levelcam1")
            {
                cameras[i].Priority = 0;
            }
            
        }
    }

    public int GetCurrentCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if(cameras[i].Priority == 1)
            {
                return i;
            }

        }

        return 0;
    }

    public void clearAllCams()
    {
        //turf off all cams
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].Priority = 0;
        }

    }

    public void SwitchToCamera(int index)
    {
        //turn on new cam
        cameras[index].Priority = 1;
    }

    

}
