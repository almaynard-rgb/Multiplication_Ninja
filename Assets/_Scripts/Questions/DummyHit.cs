//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//DummyHit.cs
//Created Date: 03/24/2025
//Last Modified: 04/03/2025


//Description: This script manages calling the question menu once the training dummy is hit.

//Log:
//03/24/2025: Created and implemented the initial functionality for this script.

//04/03/2025: Added player reference and functionality to call ''answer wrong' when the player passes this gameobjecct.

using UnityEngine;

public class DummyHit : MonoBehaviour
{
    [SerializeField] private InGameMenusController _menuController;
    [SerializeField] private GameObject _playerRef;
    [SerializeField] LevelController _levelController;


    private void OnTriggerEnter(Collider other)
    {
        _menuController.CallQuestionMenu(true);
        this.gameObject.SetActive(false);
    }


    private void Update()
    {
        if(_playerRef.transform.position.z > this.transform.position.z)
        {
            //call question wrong
            _levelController.QuestionFalse();

            //disable the object right after
            this.gameObject.SetActive(false);
        }
    }
}
