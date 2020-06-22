using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : MonoBehaviour
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
            other.gameObject.GetComponent<Player>().ChangeSubject("Math");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().ChangeSubject("None");
        }
    }

    public string[] MathQuestion()
    {
        int questionIndex = Random.Range(1, 4);

        switch (questionIndex)
        {
            case 1:
                return new[]
                {
                    "How many solutions are there to x^2 - 9 = 0?",
                    "0",
                    "1",
                    "2",
                    "3",
                    "3"
                };

            case 2:
                return new[]
                {
                    "In mathematics, 2 x 3 = 6, and 3 x 2 = 6. Also, 2 + 3 = 5 and 3 + 2 = 5. What is this property known as?",
                    "Commutivity",
                    "Associativity",
                    "Transitivity",
                    "Identity",
                    "1"
                };

            case 3:
                return new[]
                {
                    "How many unique prime factors does the number 60 have?",
                    "1",
                    "2",
                    "3",
                    "4",
                    "3"
                };
        }

        return new[] { "Error: No question retrieved." };
    }
}
