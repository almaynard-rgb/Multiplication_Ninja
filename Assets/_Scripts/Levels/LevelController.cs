//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//LevelController.cs
//Created Date: 03/27/2025
//Last Modified: 04/03/2025


//Description: This script controls the levels of the game, including: map speed, num of questions, loading the questions and saving/loading.
//attributes to change based on the level selected and it's difficulty.

//Log:
//03/27/2025: Created and implemented the basic logic flow of the functionality for this script.

//03/28/2025: Started work on logic to change when a difficulty is chosen. Also started hooking the code up to other scripts and getting the multiplication questions.

//03/29/2025: Continued work on changing values for each difficulty and setting up the questions being loaded to this script on play dynamically (based on diffculty).

//04/03/2025:   -Move functionality from question controller to this script. Ie beinng able to increment score, disbale/enable the menu etc.
//              -Tied this script to the questiuon canvas and implement score tracking woth the help of importing questions from the Multiplication questions
//              -Added user input and checks for if user input was correct compared to the current question.
//              -Added setting text on the user side for questions etc.


//04/04/2025:   -Cleaned up code, fixed randomness, added comments and added save prefs for score.


//04/04/2025: Fixed bugs and enhanced randomness. Also added more comments with win and lose point sounds.

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    //global speed values for the tiles set by the difficulty
    private float _mapSpeed = 5f;
    //global question amount set by the difficulty
    private int _numQuestions = 10;
    //global current win rate set based on the difficulty
    private float _currentWinRate;

    //current num correct/incorrect questions
    [SerializeField] private int _currentCorrectQuestions = 0;
    [SerializeField] private int _currentIncorrectQuestions = 0;
    //total nnum of questions based on difficulty
    [SerializeField] private int _totalNumQuestions;
    private List<(int, string, int, string)> _timesTable;

    [Header("Question and player input related references")]
    [SerializeField] private TextMeshProUGUI _questionPromptText;
    [SerializeField] private TMP_InputField _answerInput;

    //question and answer list
    private List<(string, int)> _questionAndAnswers = new List<(string, int)>();
    private int _currentQuestionIndex = 0; //current question indec

    [Header("Question Canvas Controller")]
    [SerializeField] private InGameMenusController _menuController;
    
    [Header("Set speed of map for each mode")]
    [SerializeField] private float _easyModeSpeed = 5f;
    [SerializeField] private float _mediumModeSpeed = 12f;
    [SerializeField] private float _hardModeSpeed = 20f;

    [Header("Set # of questions for each mode")]
    [SerializeField] private int _easyModeNumQuestions = 10;
    [SerializeField] private int _mediumModeNumQuestions = 20;
    [SerializeField] private int _hardModeNumQuestions = 30;

    [Header("Win Percentages for each mode")]
    [SerializeField] private float _easyWinRate = 70;
    [SerializeField] private float _mediumWinRate = 80;
    [SerializeField] private float _hardWinRate = 90;

    [Header("Win and Lose Point Sounds")]
    [SerializeField] private AudioSource _losePointSound;
    [SerializeField] private AudioSource _winPointSound;

    private void Awake()
    {
        //limit the characters allowed to 2 as no answers should be above 2
        _answerInput.characterLimit = 2;

        //Debug.Log($"Difficulty selected: {PlayerPrefs.GetString("DifficultySelected").ToString()}");

        //set the game parameters based on playerprefs
        switch (PlayerPrefs.GetString("DifficultySelected").ToString().ToLower())
        {
            case "easy":
                _mapSpeed = _easyModeSpeed;
                _currentWinRate = _easyWinRate;
                _numQuestions = _easyModeNumQuestions;
                break;
            case "medium":
                _mapSpeed = _mediumModeSpeed;
                _currentWinRate = _mediumWinRate;
                _numQuestions = _mediumModeNumQuestions; 
                break;
            case "hard":
                _mapSpeed = _hardModeSpeed;
                _currentWinRate = _hardWinRate;
                _numQuestions = _hardModeNumQuestions;
                break;
            default:
                _mapSpeed = _easyModeSpeed;
                _currentWinRate = _easyWinRate;
                _numQuestions = _easyModeNumQuestions;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("LevelSelected").ToString())
        {
            //case --> load question tuple class and radomize the set
            //of questions (with num of questions).
            case "1":
                _timesTable = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_1;
                break;
            case "2":
                _timesTable = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_2;
                break;
            case "3":
                _timesTable = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_3;
                break;
            case "4":
                _timesTable = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_4;
                break;
            case "5":
                _timesTable = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_5;
                break;
            case "6":
                _timesTable = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_6;
                break;
            case "7":
                _timesTable = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_7;
                break;
            case "8":
                _timesTable = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_8;
                break;
            case "9":
                _timesTable = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_9;
                break;
            default:
                _timesTable = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_1;
                break;
        }
        //load the questions after table is loaded with the num of questions needed
        LoadQuestions(_numQuestions);
    }

    // Update is called once per frame
    void Update()
    {
        //check if are done playing yet
        if((_currentCorrectQuestions + _currentIncorrectQuestions) == _numQuestions)
        {
            //if so..
            //convert the numOfQuestions and num of correctQuestions to float for later division
            float correctQuestons = _currentCorrectQuestions;
            float numQuestions = _numQuestions;
            int numQuestionsNeeded = (int)((_currentWinRate / 100) * _numQuestions);

            //set the scores values needed for the win/lose menus
            PlayerPrefs.SetInt("TotalQuestions", _numQuestions); 
            PlayerPrefs.SetInt("CorrectQuestions", _currentCorrectQuestions);
            PlayerPrefs.SetInt("NeededQuestions", numQuestionsNeeded);

            //check if we win (based on win % necessay)
            if((correctQuestons / numQuestions) >= (_currentWinRate / 100))
            {
                //if we win...
                //save based on the following. Value of the saved prefs are as follows: 1 - easy completed, 2 - medium completed, 3 - Hard completed
                switch (PlayerPrefs.GetString("DifficultySelected").ToString().ToLower())
                {
                    case "easy":
                        PlayerPrefs.SetInt(PlayerPrefs.GetString("DifficultySelected").ToString().ToLower() + " " + PlayerPrefs.GetInt("LevelSelected").ToString(), 1);
                        break;
                    case "medium":
                        PlayerPrefs.SetInt(PlayerPrefs.GetString("DifficultySelected").ToString().ToLower() + " " + PlayerPrefs.GetInt("LevelSelected").ToString(), 2);
                        break;
                    case "hard":
                        PlayerPrefs.SetInt(PlayerPrefs.GetString("DifficultySelected").ToString().ToLower() + " " + PlayerPrefs.GetInt("LevelSelected").ToString(), 3);
                        break;
                    default:
                        PlayerPrefs.SetInt(PlayerPrefs.GetString("DifficultySelected").ToString().ToLower() + " " + PlayerPrefs.GetInt("LevelSelected").ToString(), 1);
                        break;
                }
                //load win scene
                PlayerPrefs.Save(); //save player prefs
                SceneManager.LoadScene("Win");
            }
            else
            {
                PlayerPrefs.Save(); //save player prefs
                //if we don't win... simply load the lose scene
                SceneManager.LoadScene("Lose");
            }
        }

    }

    //get map speed
    public float GetMapSpeed()
    {
        return _mapSpeed;
    }

    //load the questions
    private void LoadQuestions(int numOfQuestionToLoad)
    {
        //loop to pick questions from the list randomly
        for (int i = 0; i < numOfQuestionToLoad; i++)
        {
            // Picks a number from 0 to 9 (questions 1- 10 in the MultiplicationQuestions.cs).
            System.Random rng = new();
            int questionToPick = rng.Next(0, 10); 
            _questionAndAnswers.Add((_timesTable[questionToPick].Item2, _timesTable[questionToPick].Item3)); //add the question prompt and answer
            //Debug.Log($"Question Loaded {(_timesTable[questionToPick].Item2, _timesTable[questionToPick].Item3)}");
        }
    }

    //retreive the next question by incrementing the currentQuestion index
    private void RetrieveNextQuestion()
    {
        _currentQuestionIndex++;
    }

    //check if the question answer is correct
    public void CheckQuestion()
    {
        //check player input vs question answer, reset text and indicate the question is incorrect
        if (_answerInput.text == _questionAndAnswers[_currentQuestionIndex].Item2.ToString())
        {
            //if correct get the next question ready
            RetrieveNextQuestion();
            _answerInput.text = "";
            QuestionCorrect();
        } else {
            //if incorrect get the next question ready, reset text and indicate the question is correct
            RetrieveNextQuestion();
            _answerInput.text = "";
            QuestionFalse();
        }
    }

    //what to do if question is correct
    public void QuestionCorrect()
    {
        //play sound
        _winPointSound.Play();
        //add to total correct
        _currentCorrectQuestions++;
        Debug.Log("Total correct: " + _currentCorrectQuestions);
        //call the menu to close
        _menuController.CallQuestionMenu(false); //close the question menu
    }

    //what to do if question is incorrect
    public void QuestionFalse()
    {
        //play sound
        _losePointSound.Play();
        //add to total incorrect
        //Debug.Log("Answer is false");
        _currentIncorrectQuestions++;
        Debug.Log("Total incorrect: " + _currentIncorrectQuestions);
        //call the menu to close
        _menuController.CallQuestionMenu(false); //close the question menu
    }

    //get current question prompt data for the menu
    public string GetCurrentQuestionData()
    {
        return _questionAndAnswers[_currentQuestionIndex].Item1;
    }
}