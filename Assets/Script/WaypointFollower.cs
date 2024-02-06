 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFolower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed;

    private int currenWaypointmap = 0;
   
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[currenWaypointmap].transform.position, transform.position) < .1f)
        {
            currenWaypointmap++;
            if(currenWaypointmap>= waypoints.Length)
            {
                currenWaypointmap=0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currenWaypointmap].transform.position, Time.deltaTime * speed);
    }
}
