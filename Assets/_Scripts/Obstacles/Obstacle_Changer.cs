//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//Obstacle_Changer.cs
//Created Date: 03/22/2025
//Last Modified: 03/22/2025


//Description: This script manages the placement and re-use of the obstacles on a per tile basis.
//A single obstacles is activated per tile, when that particular tile is placed at the end of the tile 'hallway'

//Log:
//03/22/2025: Created and implemented the initial functionality for this script.

using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Changer : MonoBehaviour
{
    //obstacle list
    [SerializeField] private List<GameObject> _obstacleList;
    //check to spawn with no obstacles to start
    [SerializeField] private bool _spawnWithNoObstacles;
    //index for which tile to use
    private int tileToUseIndex;

    // Start is called before the first frame update
    void Start()
    {
        //check if the tile should spawn with obsatcles to start
        if(_spawnWithNoObstacles == false)
        {
            ResetObstacles(); //reset the tiles with random obstacle placement
        } 
        else
        {
            //else turn off all obstacles
            foreach (var obstacle in _obstacleList)
            {
                obstacle.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if the tile is at the end of the 'hallway' (within a certain accuracy), then reset the obstacle
        if (this.transform.position.z <= 90.0f && this.transform.position.z >= 89.9f)
        {
            //call resest obstacles
            ResetObstacles();
        }
    }

    //reset the obstacles randomly
    void ResetObstacles()
    {
        //make sure each obstacle is de-activated
        foreach (var obstacle in _obstacleList)
        {
            obstacle.SetActive(false);
        }

        //set an obstacle to activate randomly
        tileToUseIndex = Random.Range(0, _obstacleList.Count);
        _obstacleList[tileToUseIndex].SetActive(true); //set obstacle active
    }
}
