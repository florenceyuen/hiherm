using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    public GameObject quizPanel;

    public Button nextButton;

    private List<Quiz> quizzes = new List<Quiz> {
        new Quiz(
            "What is the powerhouse of the cell?",
            "Cell membrane",
            "Golgi bodies",
            "Mitochondria",
            "Chloroplasts",
            3
        ),
        new Quiz(
            "What is the colour of the sky?",
            "Blue",
            "Red",
            "Yellow",
            "Green",
            1
        ),
        new Quiz(
            "What is the answer to 4 x 7?",
            "21",
            "32",
            "25",
            "28",
            4
        )
    };

    private int currentQuiz = 0;

    private ColorBlock defaultColours;

    // Start is called before the first frame update
    void Start() {
        defaultColours = quizPanel.transform.GetChild(1).GetComponent<Button>().colors;
        loadQuestion();
    }

    void loadQuestion() {
        // reset the appearance of and enable all the buttons
        for (int i = 1; i < 5; i++) {
            quizPanel.transform.GetChild(i).GetComponent<Button>().colors = defaultColours;
            quizPanel.transform.GetChild(i).GetComponent<Button>().enabled = true;
        }

        // load all of the question information
        quizPanel.transform.GetChild(0).GetComponent<Text>().text = quizzes[currentQuiz].question;
        quizPanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = quizzes[currentQuiz].answer1;
        quizPanel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = quizzes[currentQuiz].answer2;
        quizPanel.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = quizzes[currentQuiz].answer3;
        quizPanel.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = quizzes[currentQuiz].answer4;

        // hide the next button and response text
        nextButton.gameObject.SetActive(false);
        quizPanel.transform.GetChild(5).GetComponent<Text>().text = "";
    }

    // process whether the answer is correct or incorrect
    public void processAnswer(int selected) {
        // prevent all the buttons from being interactable
        for (int i = 1; i < 5; i++) {
            quizPanel.transform.GetChild(i).GetComponent<Button>().enabled = false;
        }

        ColorBlock correctColors = defaultColours;
        ColorBlock incorrectColors = defaultColours;

        // change the correct button to green
        correctColors.normalColor = Color.green;
        quizPanel.transform.GetChild(quizzes[currentQuiz].correct).GetComponent<Button>().colors = correctColors;
        
        // if we selected the wrong one, change it to red
        if (selected != quizzes[currentQuiz].correct) {
            incorrectColors.normalColor = Color.red;
            quizPanel.transform.GetChild(selected).GetComponent<Button>().colors = incorrectColors;
        }
        
        // update the text at the bottom to tell them if it was correct
        if (selected == quizzes[currentQuiz].correct) {
            quizPanel.transform.GetChild(5).GetComponent<Text>().text = "Correct answer!";
        } else {
            quizPanel.transform.GetChild(5).GetComponent<Text>().text = "Incorrect answer.";
        }

        // make the next button appear
        if (quizzes.Count > currentQuiz + 1) {
            nextButton.gameObject.SetActive(true);
        }
    }

    // advance to the next quiz
    public void nextQuiz() {
        currentQuiz++;
        loadQuestion();
    }

    // Update is called once per frame
    void Update() {
        // do nothing
    }
}
