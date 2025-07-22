//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//QuestionCanvasController.cs
//Created Date: 03/24/2025
//Last Modified: 04/04/2025


//Description: This script manages the opening and closing of the question menu and pause menu objects as well as
//they're functionality in terms of pausing, resuming, calling the menus and returning to the main menu.

//Log:
//03/24/2025: Created and implemented the initial functionality for this script.

//04/04/2025: Incorporated the pause menu as a part of this script to group up functionality and not have timescale conflicts.

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenusController : MonoBehaviour
{
    //checks for both menus
    private bool _isQuestionMenuActive = false;
    private bool _isPauseMenuActive = false;

    [Header("Menus")]
    [SerializeField] private GameObject _questionMenu;
    [SerializeField] private GameObject _pauseMenu;

    [Header("Question Text")]
    [SerializeField] private TextMeshProUGUI _questionText;

    [Header("Level Controller")]
    [SerializeField] private LevelController _levelController;

    // Update is called once per frame
    void Update()
    {
        //check for input to bring up the pause menu
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu.SetActive(true);
            _isPauseMenuActive = true;
            Time.timeScale = 0.0f;
        }

        //check if we need to load the quetion menu
        if (_isQuestionMenuActive == true && _isPauseMenuActive == false)
        {
            _questionText.text = "What is " + _levelController.GetCurrentQuestionData() + "?";
            Time.timeScale = 0.0f;
            _questionMenu.SetActive(true);
        }
        //check if we should resume the game after answering a question
        else if (_isQuestionMenuActive == false && _isPauseMenuActive == false)
        {
            Time.timeScale = 1.0f;
            _questionMenu.SetActive(false);
        }
    }

    //call the question menu
    public void CallQuestionMenu(bool open)
    {
        if(open == true)
        {
            _isQuestionMenuActive = true;
        } 
        else
        {
            _isQuestionMenuActive = false;
        }
    }

    //resume the game from pause menu
    public void Resume()
    {
        _isPauseMenuActive = false;
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
    }

    //return to the main menu from pause menu
    public void ReturnToMainMenu()
    {
        _isPauseMenuActive = false;
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
