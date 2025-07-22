//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//Tile_Mover.cs
//Created Date: 03/22/2025
//Last Modified: 03/28/2025

//Description: This script manages moving all the tiles

//Log:
//03/22/2025: Created and implemented the initial functionality for this script.
//03/28/2025: Updated the script where the speed of the tiles is derived from the LevelController script.

using UnityEngine;
public class Tile_Mover : MonoBehaviour
{
    //speed value
    [SerializeField] private LevelController _levelController;

    // Update is called once per frame
    void FixedUpdate()
    {
        //move the tile oject using speed and time. Speed is negative to set the direction
        transform.Translate(-_levelController.GetMapSpeed() * Time.deltaTime * Vector3.forward);
    }
}