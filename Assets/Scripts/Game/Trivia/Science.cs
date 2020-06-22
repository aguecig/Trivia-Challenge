using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Science : MonoBehaviour
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
            other.gameObject.GetComponent<Player>().ChangeSubject("Science");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().ChangeSubject("None");
        }
    }

    public string[] ScienceQuestion()
    {
        int questionIndex = Random.Range(1, 4);

        switch (questionIndex)
        {
            case 1:
                return new[]
                {
                    "Who won the noble prize for their discovery of the photoelectric effect?",
                    "Newton",
                    "Einstein",
                    "Hawking",
                    "Bohr",
                    "2"
                };

            case 2:
                return new[]
                {
                    "In chemistry, elements can have isotopes. Which subatomic particle changes in number between isotopes of an element?",
                    "Proton",
                    "Electron",
                    "Quark",
                    "Neutron",
                    "4"
                };

            case 3:
                return new[]
                {
                    "How many chromsomes does a human have?",
                    "46",
                    "24",
                    "23",
                    "48",
                    "1"
                };
        }

        return new[] { "Error: No question retrieved." };
    }
}
