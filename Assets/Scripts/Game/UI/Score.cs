using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public void ChangeScoreText(int score)
    {
        _text.text = "SCORE: " + score;
    }

    public void SetActiveStatus(bool status)
    {
        this.gameObject.SetActive(status);
    }
}
