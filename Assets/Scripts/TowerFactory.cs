using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    private int currentTowers = 0;

    public void AddTower(Node towerBase) {
        if (currentTowers < towerLimit) {
            currentTowers++;
            InstantiateNewTower(towerBase);
        } else {
            MoveExistingTower();
        }
    }

    private void InstantiateNewTower(Node towerBase) {
        GameObject newTower = Instantiate(towerPrefab, towerBase.transform.position, Quaternion.identity).gameObject;
        newTower.transform.parent = towerBase.transform;
        print(gameObject.name + "created");
    }

    private void MoveExistingTower() {
        throw new NotImplementedException();
    }
}
