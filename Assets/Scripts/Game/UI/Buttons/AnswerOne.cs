using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerOne : MonoBehaviour
{
    [SerializeField]
    private bool _isCorrectAnswer = false;
    [SerializeField]
    private Text _answerText;

    [SerializeField]
    private GameObject _questionImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAnswerStatus(string answer, string correctAnswer)
    {
        _answerText.text = answer;

        if (correctAnswer == "1")
        {
            _isCorrectAnswer = true;
        }

        else
        {
            _isCorrectAnswer = false;
        }
    }

    public void OnButtonClick()
    {
        _questionImage.transform.GetComponent<Question>().DisplayAnswerMessage(_isCorrectAnswer);
    }

    public void DisableButton()
    {
        transform.GetComponent<Button>().interactable = false;
    }

    public void EnableButton()
    {
        transform.GetComponent<Button>().interactable = true;
    }
}
