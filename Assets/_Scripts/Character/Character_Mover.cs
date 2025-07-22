//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//Character_Mover.cs
//Created Date: 03/24/2025
//Last Modified: 03/24/2025


//Description: This script manages the horizontal movement of the player.

//Log:
//03/24/2025: Created and implemented the initial functionality for this script.

using UnityEngine;

public class Character_Mover : MonoBehaviour
{
    //player move speed
    [SerializeField] private float _playerMoveSpeed = 6.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //move playe by getting input and multiplying it by the speed
        transform.Translate(_playerMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime * Vector3.right);
    }
}
