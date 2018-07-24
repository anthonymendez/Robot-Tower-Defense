using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyCountUpdater : MonoBehaviour {

    [SerializeField] int amountOfEnemiesOnBoard = 0;
    [SerializeField] List<Text> enemyCountTexts;

    void Start() {
        enemyCountTexts = GetComponentsInChildren<Text>().ToList<Text>();
        RefreshEnemyCountTexts();
    }

    public void AdjustEnemyCount(int difference) {
        amountOfEnemiesOnBoard += difference;
        RefreshEnemyCountTexts();
    }

    private void RefreshEnemyCountTexts() {
        foreach (Text enemyCountText in enemyCountTexts) {
            enemyCountText.text = amountOfEnemiesOnBoard.ToString();
        }
    }
}
