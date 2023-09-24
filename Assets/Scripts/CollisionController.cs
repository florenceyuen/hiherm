using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private GameObject science;
    private GameObject math;
    private GameObject english;
    private GameObject socialStudies;
    // private QuizController QuizController;
    private bool colliding = false;
    private void Start()
    {
        science = GameObject.Find("science");
        math = GameObject.Find("math");
        english = GameObject.Find("english");
        socialStudies = GameObject.Find("social studies");
        science.gameObject.SetActive(false);
        math.gameObject.SetActive(false);
        english.gameObject.SetActive(false);
        socialStudies.gameObject.SetActive(false);
        // QuizController = GameObject.Find("GameManager").GetComponent<QuizController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
        if (collision.gameObject.name == "purple planet")
        {
            science.gameObject.SetActive(true);
            QuizController.changeTopic("Science");
        }
        if (collision.gameObject.name == "turq planet")
        {
            math.gameObject.SetActive(true);
            QuizController.changeTopic("Math");
        }
        if (collision.gameObject.name == "green planet")
        {
            english.gameObject.SetActive(true);
            QuizController.changeTopic("English");
        }
        if (collision.gameObject.name == "blue planet")
        {
            socialStudies.gameObject.SetActive(true);
            QuizController.changeTopic("Social Studies");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
        if (collision.gameObject.name == "purple planet")
        {
            science.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "turq planet")
        {
            math.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "green planet")
        {
            english.gameObject.SetActive(false);
        }
        if (collision.gameObject.name == "blue planet")
        {
            socialStudies.gameObject.SetActive(false);
        }
    }

    void Update() {
        // if they press enter while colliding, we should open the quiz
        if (Input.GetKeyDown(KeyCode.Return) && colliding) {
            ChangeScene.ChangeToScene("QuizCardScene");
        }
    }
}
