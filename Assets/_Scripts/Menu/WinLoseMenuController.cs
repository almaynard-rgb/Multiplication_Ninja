//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//MainMenuController.cs
//Created Date: 03/27/2025
//Last Modified: 03/27/2025


//Description: This script manages the win and lose menu button options and displaying of scores

//Log:
//03/27/2025: Created and implemented the full functionality for this script

using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WInLoseMenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText.text = $"You got {PlayerPrefs.GetInt("CorrectQuestions")} out of {PlayerPrefs.GetInt("TotalQuestions")} questions correct.\nYou needed {PlayerPrefs.GetInt("NeededQuestions")} to win.";
    }

    //play the game
    public void MainMenu()
    {
        //reset score save prefs
        PlayerPrefs.SetInt("TotalQuestions", 0);
        PlayerPrefs.SetInt("CorrectQuestions", 0);
        PlayerPrefs.SetInt("NeededQuestions", 0);

        PlayerPrefs.Save(); //save

        //get the level select scene
        SceneManager.LoadScene("LevelSelect");
    }

    //quit the game
    public void Quit()
    {
        //reset score save prefs
        //reset score save prefs
        PlayerPrefs.SetInt("TotalQuestions", 0);
        PlayerPrefs.SetInt("CorrectQuestions", 0);
        PlayerPrefs.SetInt("NeededQuestions", 0);

        PlayerPrefs.Save(); //save

        //if in unity editor stop the playing of the scene, else in build just quit
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Quits the built application
#endif
    }
}
