//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//DifficultyManager.cs
//Created Date: 03/27/2025
//Last Modified: 04/04/2025

//Description: This script sets the game difficulty after a button is pressed

//Log:
//03/27/2025: Created and implemented the full functionality for this script.

//04/04/2025: Added functionaliy to go back to the level select menu

using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public void DifficultySelect(string difficultySelected)
    {
        //set5 player prefs for difficulty
        PlayerPrefs.SetString("DifficultySelected", difficultySelected.ToLower());
        PlayerPrefs.Save(); //save
        //message
        Debug.Log($"{difficultySelected} difficulty was selected");
        SceneManager.LoadScene("GameScene"); //load the gamescene
    }

    //go back to the level select
    public void BackToLevelSelect()
    {
        //load level select scene
        SceneManager.LoadScene("LevelSelect");
    }
}
