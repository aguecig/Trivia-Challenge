using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _playerScore = 0;
    [SerializeField]
    private float _playerSpeed = 5.0f;
    [SerializeField]
    private string _currentSubject = "None";
    [SerializeField]
    private Rigidbody2D _playerRigidbody;
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private GameObject _questionImage;

    [SerializeField]
    private GameObject _scoreImage;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = transform.GetComponent<Rigidbody2D>();
        _animator = transform.GetComponent<Animator>();
        _questionImage = GameObject.Find("Canvas").gameObject.transform.GetChild(1).gameObject;
        _scoreImage = GameObject.Find("Canvas").gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        GetQuestion();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0)
        {
            Vector2 velocity = new Vector2(horizontalInput, 0);
            _playerRigidbody.MovePosition(_playerRigidbody.position + _playerSpeed * velocity * Time.fixedDeltaTime);
            SetPlayerAnimation(horizontalInput, 0);
        }

        else if (verticalInput != 0)
        {
            Vector2 velocity = new Vector2(0, verticalInput);
            _playerRigidbody.MovePosition(_playerRigidbody.position + _playerSpeed * velocity * Time.fixedDeltaTime);
            SetPlayerAnimation(0, verticalInput);
        }

        if (horizontalInput == 0 && verticalInput == 0)
        {
            SetPlayerAnimation(0, 0);
        }
    }

    void SetPlayerAnimation(float h, float v)
    {
        // reverse transform scale if player is moving left
        if ((h > 0 && transform.localScale.x < 0) || (h < 0 && transform.localScale.x > 0))
        {
            Vector3 tempVector = transform.localScale;
            tempVector.x *= -1;
            transform.localScale = tempVector;
        }

        if (h > 0)
        {
            _animator.SetFloat("right", h);
        }

        else if (h < 0)
        {
            _animator.SetFloat("left", -1*h);
        }

        else if (v > 0)
        {
            _animator.SetFloat("up", v);
        }
            
        else if (v < 0)
        {
            _animator.SetFloat("down", -1*v);
        }

        if (h == 0)
        {
            _animator.SetFloat("right", 0);
            _animator.SetFloat("left", 0);
        }

        if (v == 0)
        {
            _animator.SetFloat("up", 0);
            _animator.SetFloat("down", 0);
        }
    }

    void GetQuestion()
    {
        if (_currentSubject != "None" && Input.GetKeyDown(KeyCode.C) == true)
        {
            _questionImage.GetComponent<Question>().AskQuestion(_currentSubject);
            this.gameObject.SetActive(false);
        }
    }

    public void ChangeSubject(string subject)
    {
        _currentSubject = subject;
    }

    public void ReactivatePlayer()
    {
        this.gameObject.SetActive(true);
    }

    public void ChangePlayerScore(int modifier)
    {
        _playerScore += modifier;
        _scoreImage.GetComponent<Score>().ChangeScoreText(_playerScore);
    }
}
