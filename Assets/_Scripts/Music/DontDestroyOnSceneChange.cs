//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//DontDestroyOnSceneChange.cs
//Created Date: 04/04/2025
//Last Modified: 04/04/2025


//Description: This script manages the menu music and ensures that it does not stop playing between menus.

//Log:
//03/27/2025: Created and implemented the full functionality for this script

using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnSceneChange : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //ensure the object is not destroyed
        //make sure there is only onne object
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject); // If another instance exists, destroy this one
            return;
        }

    }

    private void Update()
    {
        //if we are in the gamescene then destroy it
        if(SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name == "Lose")
        {
            Destroy(gameObject);
        }
    }
}
