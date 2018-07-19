using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> towersOnMap = new Queue<Tower>();

    public void AddTower(Node towerBase) {
        if (towersOnMap.Count < towerLimit) {
            InstantiateNewTower(towerBase);
        } else {
            MoveExistingTower(towerBase);
        }
    }

    private void InstantiateNewTower(Node towerBase) {
        Tower newTower = Instantiate(towerPrefab, towerBase.transform.position, Quaternion.identity);
        towerBase.isPlaceable = false;
        newTower.baseNode = towerBase;
        newTower.transform.parent = towerBase.transform;
        towersOnMap.Enqueue(newTower);
    }

    private void MoveExistingTower(Node towerBase) {
        Tower towerToMove = towersOnMap.Dequeue();
        towerToMove.baseNode.isPlaceable = true;
        towerBase.isPlaceable = false;
        towerToMove.transform.parent = towerBase.transform;
        towerToMove.transform.position = towerBase.transform.position;
        towerToMove.baseNode = towerBase;
        towersOnMap.Enqueue(towerToMove);
    }
}
