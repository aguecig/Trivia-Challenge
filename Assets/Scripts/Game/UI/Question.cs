using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField]
    private Text _questionText;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private GameObject _scoreImage;

    [SerializeField]
    private GameObject _answerOne;
    [SerializeField]
    private GameObject _answerTwo;
    [SerializeField]
    private GameObject _answerThree;
    [SerializeField]
    private GameObject _answerFour;

    [SerializeField]
    private Science _science;
    [SerializeField]
    private History _history;
    [SerializeField]
    private Literature _literature;
    [SerializeField]
    private Math _math;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AskQuestion(string subject)
    {
        _scoreImage.GetComponent<Score>().SetActiveStatus(false);

        this.gameObject.SetActive(true);

        _answerOne.GetComponent<AnswerOne>().EnableButton();
        _answerTwo.GetComponent<AnswerTwo>().EnableButton();
        _answerThree.GetComponent<AnswerThree>().EnableButton();
        _answerFour.GetComponent<AnswerFour>().EnableButton();

        string[] question = { "No Question yet" };

        if (subject == "Science")
        {
            question = _science.ScienceQuestion();
        }

        else if (subject == "History")
        {
            question = _history.HistoryQuestion();
        }

        else if (subject == "Literature")
        {
            question = _literature.LiteratureQuestion();
        }

        else if (subject == "Math")
        {
            question = _math.MathQuestion();
        }

        _questionText.text = question[0];

        _answerOne.GetComponent<AnswerOne>().ChangeAnswerStatus(question[1], question[5]);
        _answerTwo.GetComponent<AnswerTwo>().ChangeAnswerStatus(question[2], question[5]);
        _answerThree.GetComponent<AnswerThree>().ChangeAnswerStatus(question[3], question[5]);
        _answerFour.GetComponent<AnswerFour>().ChangeAnswerStatus(question[4], question[5]);
    }

    public void DisplayAnswerMessage(bool isCorrect)
    {
        if (isCorrect == true)
        {
            _questionText.text = "Correct!";
            _player.ChangePlayerScore(10);
        }

        else
        {
            _questionText.text = "Incorrect.";
            _player.ChangePlayerScore(-10);
        }

        _answerOne.GetComponent<AnswerOne>().DisableButton();
        _answerTwo.GetComponent<AnswerTwo>().DisableButton();
        _answerThree.GetComponent<AnswerThree>().DisableButton();
        _answerFour.GetComponent<AnswerFour>().DisableButton();

        StartCoroutine(DeactivateQuestionRoutine());
    }

    IEnumerator DeactivateQuestionRoutine()
    {
        yield return new WaitForSeconds(2);

        this.gameObject.SetActive(false);

        _player.ReactivatePlayer();

        _scoreImage.GetComponent<Score>().SetActiveStatus(true);
    }
}
