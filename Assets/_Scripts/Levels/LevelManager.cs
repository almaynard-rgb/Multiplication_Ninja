//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//LevelManager.cs
//Created Date: 03/27/2025
//Last Modified: 04/04/2025


//Description: This script sets the game level selection after a button press.

//Log:
//03/27/2025: Created and implemented the full functionality for this script.

//04/04/2025: Added functionaliy to go back to the main menu

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //select a level
    public void LevelSelect(int levelSelected)
    {
        //set the level select to playerprefs
        PlayerPrefs.SetInt("LevelSelected", levelSelected);
        PlayerPrefs.Save(); //save
        //load the scene
        SceneManager.LoadScene("DifficultySelect");
        Debug.Log($"Level {levelSelected} was selected");
    }

    //back to the main menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}