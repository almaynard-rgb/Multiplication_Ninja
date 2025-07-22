//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//Tile_Spawner_Despawner.cs
//Created Date: 03/22/2025
//Last Modified: 03/22/2025


//Description: This script manages the placement and re-use of the tiles.
//When a tile passes behind the player and is out of view, it is 're-spawned' (moved)
//at the end of the tile 'hallway'. All tiles move from the front to the end in an
//endless loop.

//Log:
//03/22/2025: Created and implemented the initial functionality for this script.

using System;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Spawner_Despawner : MonoBehaviour
{
    //list of tiles
    [SerializeField] private List<GameObject> _tileList;
    //start tile index.
    private int _startTileIndex = 0;
    //end tile index.
    private int _endTileIndex = 9;
    //start and end tiles
    private GameObject _startTile;
    private GameObject _endTile;

    // Start is called before the first frame update
    void Start()
    {
        //set the start and end tiles using the index in the list of tiles.
        _startTile = _tileList[_startTileIndex];
        _endTile = _tileList[_endTileIndex];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //make sure that we check if the tile is out of view, within a specific certainty
        //the Math.Abs check helps with Gaps
        if(Math.Abs(_startTile.transform.position.z - (-10f)) < 0.01f)
        {
            //move the start tile, to the end and round to ensure no gaps
            _startTile.transform.position = new Vector3(0, 0, Mathf.Round(_endTile.transform.position.z + 10f));            
            //makes sure to set the next index. Modulus operator helps with looping endlessly
            _startTileIndex = (_startTileIndex + 1) % _tileList.Count;
            
            //makes sure to set the next index. Modulus operator helps with looping endlessly.
            //we use the start index in the calculation to ensure that the end tile is rightr behind the start tile 
            //and that they start and end tiles dont overlap.
            _endTileIndex = (_startTileIndex - 1 + _tileList.Count) % _tileList.Count;

            //set the start and end tiles with the proper indexes
            _startTile = _tileList[_startTileIndex];
            _endTile = _tileList[_endTileIndex];
        }
    }
}
