using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameControlsImage;

    public void OnNoticeClick()
    {
        _gameControlsImage.gameObject.SetActive(true);
    }

    public void OnNoticeClose()
    {
        _gameControlsImage.gameObject.SetActive(false);
    }

    public void OnNewStartClick()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
