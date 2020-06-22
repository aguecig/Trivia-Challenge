using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour
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
            other.gameObject.GetComponent<Player>().ChangeSubject("History");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().ChangeSubject("None");
        }
    }

    public string[] HistoryQuestion()
    {
        int questionIndex = Random.Range(1, 4);

        switch (questionIndex)
        {
            case 1:
                return new[]
                {
                    "Who was the first Roman Emperor?",
                    "Augustus",
                    "Julius",
                    "Tiberius",
                    "Caligula",
                    "1"
                };

            case 2:
                return new[]
                {
                    "In what year was the town of Salem, Massachusetts founded?",
                    "1598",
                    "1703",
                    "1626",
                    "1811",
                    "3"
                };

            case 3:
                return new[]
                {
                    "Who sent the Spanish Armada to England in 1588?",
                    "Henry VII",
                    "Phillip II",
                    "George",
                    "Henry V",
                    "2"
                };
        }

        return new[] { "Error: No question retrieved." };
    }
}
