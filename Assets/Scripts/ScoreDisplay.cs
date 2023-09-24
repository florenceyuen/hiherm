using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    public Text scoreText;

    void Awake() {
        scoreText.text = System.String.Format("{0}/{1}", QuizController.scoreNumerator, QuizController.scoreDenominator);
    }
}
