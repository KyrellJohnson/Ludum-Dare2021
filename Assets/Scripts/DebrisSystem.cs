using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSystem : MonoBehaviour
{
    public Transform playerPos;
    

    private float maxOffsetX = 9f;
    private float minOffsetX = -9f;
    private float minOffsetY = -10f;
    private float maxOffsetY = 10f;

    [SerializeField]
    private float 
        timeInterval = 20,
        minimumNumberOfSpawnable = 3,
        maximumNumberOfSpawnable = 8;

    public GameObject[] SpawnableObjects;

    private float Timer = 0f;

    private CameraSwitchHandler cams;

    private void Awake()
    {
        cams = GameObject.Find("CameraHandler").GetComponent<CameraSwitchHandler>();
    }

    private void Update()
    {
        Timer += Time.deltaTime; //increase time every frame
        if(Timer > timeInterval)
        {

            // spawn objects
            SpawnDebris();

            //reset timer
            Timer = 0f;
     
        }
    }

  
    void SpawnDebris()
    {
        Vector2 targetpos; 
        
        // Spawn the number of objects
        float RandNoOfObjects = Random.Range(minimumNumberOfSpawnable, maximumNumberOfSpawnable);

        for(int i = 0; i < RandNoOfObjects; i++)
        {
            float randomXoffset = Random.Range(minOffsetX, maxOffsetX);
            float randomYoffset = Random.Range(minOffsetY, maxOffsetY);
            targetpos = new Vector2(randomXoffset, playerPos.position.y + 35 + randomYoffset);
            int randGameObjectIndex = Random.Range(0, SpawnableObjects.Length);
            GameObject debris = Instantiate(SpawnableObjects[randGameObjectIndex], targetpos, Quaternion.identity);
            debris.transform.SetParent(gameObject.transform);
        }

        
    }

}
