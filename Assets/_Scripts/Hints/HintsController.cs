using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintsController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _hintText;
    [SerializeField] GameObject _multiplyMaster;
    //string for the hint
    private string _hint;

    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("LevelSelected").ToString())
        {
            //case --> load question tuple class and radomize the set
            //of questions (with num of questions).
            case "1":
                _hint = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_1[0].Item4;
                break;
            case "2":
                _hint = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_2[0].Item4;
                break;
            case "3":
                _hint = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_3[0].Item4;
                break;
            case "4":
                _hint = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_4[0].Item4;
                break;
            case "5":
                _hint = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_5[0].Item4;
                break;
            case "6":
                _hint = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_6[0].Item4;
                break;
            case "7":
                _hint = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_7[0].Item4;
                break;
            case "8":
                _hint = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_8[0].Item4;
                break;
            case "9":
                _hint = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_9[0].Item4;
                break;
            default:
                _hint = gameObject.AddComponent<MultiplicationQuestions>()._timesTable_1[0].Item4;
                break;
        }
    }

    //set the hint on
    public void SetHintOn() {
        _hintText.text = _hint;
        _multiplyMaster.SetActive(true);
    }
}
