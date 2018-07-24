using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

    [SerializeField] int score = 0;
    [SerializeField] List<Text> scoreTexts;

    void Start() {
        scoreTexts = GetComponentsInChildren<Text>().ToList<Text>();
        RefreshScoreTexts();
    }

    public void IncrementScore(int scoreToIncreaseBy) {
        score += scoreToIncreaseBy;
        RefreshScoreTexts();
    }

    private void RefreshScoreTexts() {
        foreach (Text scoreText in scoreTexts) {
            scoreText.text = score.ToString();
        }
    }

}
