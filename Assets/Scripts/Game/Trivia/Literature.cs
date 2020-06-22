using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Literature : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().ChangeSubject("Literature");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().ChangeSubject("None");
        }
    }

    public string[] LiteratureQuestion()
    {
        int questionIndex = Random.Range(1, 4);

        switch (questionIndex)
        {
            case 1:
                return new[]
                {
                    "Who is Cassio's love interest in Shakespeare's Othello?",
                    "Katherina",
                    "Desdemona",
                    "Cordelia",
                    "Bianca",
                    "4"
                };

            case 2:
                return new[]
                {
                    "Which of the following is not a poem written by Edgar Allen Poe?",
                    "Annabel Lee",
                    "The Bells",
                    "Fire and Ice",
                    "Lenore",
                    "3"
                };

            case 3:
                return new[]
                {
                    "In Catch 22, which character cannot frequently talk because he puts crab apples in his mouth?",
                    "Dunbar",
                    "Orr",
                    "Yossarion",
                    "Major Major",
                    "2"
                };
        }

        return new[] { "Error: No question retrieved." };
    }
}
