using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    public GameObject quizPanel;

    public Button nextButton;

    private Dictionary<string, List<Quiz>> quizzes = new Dictionary<string, List<Quiz>>();
    
    public static string topic = "Science";

    private static int currentQuiz = 0;

    private ColorBlock defaultColours;

    public static int scoreNumerator = 0;
    public static int scoreDenominator = 0;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("the quiz controller exists.");
        loadQuizzes();
        defaultColours = quizPanel.transform.GetChild(1).GetComponent<Button>().colors;
        loadQuestion();
    }

    void loadQuizzes() {
        quizzes["Math"] = new List<Quiz>() {
            new Quiz(
                "What is 12 + 43?",
                "55",
                "1243",
                "57",
                "45",
                1
            ),
            new Quiz(
                "What is 45 - 20?",
                "65",
                "43",
                "20",
                "25",
                4
            ),
            new Quiz(
                "What is 4 x 7?",
                "21",
                "32",
                "25",
                "28",
                4
            )
        };
        quizzes["Science"] = new List<Quiz>() {
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
                "How many bones are in the human body?",
                "201",
                "206",
                "106",
                "101",
                2
            )
        };
        quizzes["English"] = new List<Quiz>() {
            new Quiz(
                "Select the grammatically correct sentence.",
                "Johnny and me eats cake",
                "Johnny and me eat cake",
                "Johnny and I eat cake",
                "Johnny and I eats cake",
                3
            ),
            new Quiz(
                "Select the correctly spelled word.",
                "special",
                "spiecal",
                "spesial",
                "speciel",
                1
            ),
            new Quiz(
                "What type of speech is the word 'beautiful'?",
                "verb",
                "noun",
                "conjunctive",
                "adjective",
                4
            )
        };
        quizzes["Social Studies"] = new List<Quiz>() {
            new Quiz(
                "When did Canada become independent?",
                "1867",
                "1865",
                "1967",
                "1965",
                1
            ),
            new Quiz(
                "How many provinces are there in Canada?",
                "13",
                "11",
                "9",
                "10",
                4
            ),
            new Quiz(
                "What are the official languages of Canada?",
                "English and Spanish",
                "English and French",
                "Just English",
                "English and Chinese",
                2
            )
        };
    }

    static public void changeTopic(string newTopic) {
        topic = newTopic;
        currentQuiz = 0;
        scoreNumerator = 0;
    }

    void loadQuestion() {
        // reset the appearance of and enable all the buttons
        for (int i = 1; i < 5; i++) {
            quizPanel.transform.GetChild(i).GetComponent<Button>().colors = defaultColours;
            quizPanel.transform.GetChild(i).GetComponent<Button>().enabled = true;
        }

        // load all of the question information
        quizPanel.transform.GetChild(0).GetComponent<Text>().text = quizzes[topic][currentQuiz].question;
        quizPanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = quizzes[topic][currentQuiz].answer1;
        quizPanel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = quizzes[topic][currentQuiz].answer2;
        quizPanel.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = quizzes[topic][currentQuiz].answer3;
        quizPanel.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = quizzes[topic][currentQuiz].answer4;

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
        quizPanel.transform.GetChild(quizzes[topic][currentQuiz].correct).GetComponent<Button>().colors = correctColors;
        
        // if we selected the wrong one, change it to red
        if (selected != quizzes[topic][currentQuiz].correct) {
            incorrectColors.normalColor = Color.red;
            quizPanel.transform.GetChild(selected).GetComponent<Button>().colors = incorrectColors;
        }
        // otherwise let's give them a point
        else {
            scoreNumerator++;
        }
        
        // update the text at the bottom to tell them if it was correct
        if (selected == quizzes[topic][currentQuiz].correct) {
            quizPanel.transform.GetChild(5).GetComponent<Text>().text = "Correct answer!";
        } else {
            quizPanel.transform.GetChild(5).GetComponent<Text>().text = "Incorrect answer.";
        }

        // make the next button appear
        nextButton.gameObject.SetActive(true);
    }

    // advance to the next quiz
    public void nextQuiz() {
        currentQuiz++;
        // if we are at the end of the quiz, change scene
        if (currentQuiz >= quizzes[topic].Count) {
            scoreDenominator = quizzes[topic].Count;
            // reset the question number for the next quiz
            currentQuiz = 0;
            // switch scene
            ChangeScene.ChangeToScene("EndingScene");
        } else {
            loadQuestion();
        }
    }

    // Update is called once per frame
    void Update() {
        // do nothing
    }
}
