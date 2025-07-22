//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//BeltAcheivementManager.cs
//Created Date: 04/03/2025
//Last Modified: 04/03/2025


//Description: This script manages the unlocked belt acheivements for all levels.

//Log:
//04/03/2025: Created and implemented the functionality for this script.

using UnityEngine;

public class BeltAcheivementManager : MonoBehaviour
{

    [Header("Belt Acheivement Images")]
    [SerializeField] private GameObject _beltEasy;
    [SerializeField] private GameObject _beltMedium;
    [SerializeField] private GameObject _beltHard;

    [Header("Mode Buttons")]
    [SerializeField] private GameObject _easyButton;
    [SerializeField] private GameObject _mediumButton;
    [SerializeField] private GameObject _hardButton;


    // Start is called before the first frame update
    void Start()
    {
        //set belts initial as false (to remove bugs)
        _beltEasy.SetActive(false);
        _beltMedium.SetActive(false);
        _beltHard.SetActive(false);

        //easy button should alwasy be set, while the other two off initially to stop bugs
        _easyButton.SetActive(true);
        _mediumButton.SetActive(false);
        _hardButton.SetActive(false);

        //select buttons/belt acheivements to show based on player prefs.
        switch (PlayerPrefs.GetInt(PlayerPrefs.GetString("DifficultySelected").ToString().ToLower() + " " + PlayerPrefs.GetInt("LevelSelected").ToString()).ToString())
        {
            //set the proper achievements/buttons based on player progression
            case "1":
                _mediumButton.SetActive(true);
                _beltEasy.SetActive(true);
                break;
            case "2":
                _mediumButton.SetActive(true);
                _hardButton.SetActive(true);
                _beltEasy.SetActive(true);
                _beltMedium.SetActive(true);
                break;
            case "3":
                _mediumButton.SetActive(true);
                _hardButton.SetActive(true);
                _beltEasy.SetActive(true);
                _beltMedium.SetActive(true);
                _beltHard.SetActive(true);
                break;
        }
    }
}
