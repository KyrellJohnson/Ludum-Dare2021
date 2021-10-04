using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> points;
    public Transform platform;

    int goalPoint = 0;

    public float moveSpeed = 2;

    private void Update()
    {
        moveToNextPoint();   
    }

    void moveToNextPoint()
    {
        //change position of platform
        platform.position = Vector2.MoveTowards(platform.position, points[goalPoint].position, Time.deltaTime*moveSpeed);
        //check if we are very close proximity
        if(Vector2.Distance(platform.position, points[goalPoint].position) < 0.1f)
        {
            // if so, change goal point to next one
            if(goalPoint==points.Count-1)
            {
                goalPoint = 0;
            }
            else
            {
                goalPoint++;
            }
            //Check if we reached last element, reset to 0 index

        }

    }


}
