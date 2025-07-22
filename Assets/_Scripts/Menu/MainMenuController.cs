//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//MainMenuController.cs
//Created Date: 03/27/2025
//Last Modified: 03/27/2025


//Description: This script manages the main menu button options

//Log:
//03/27/2025: Created and implemented the full functionality for this script.

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    //play the game
    public void Play()
    {
        //get the level select scene
        SceneManager.LoadScene("LevelSelect");
    }

    //quit the game
    public void Quit()
    {
        //if in unity editor stop the playing of the scene, else in build just quit
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Quits the built application
#endif
    }

    //clear all saves
    public void ClearSaves()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save(); //save
    }
}
