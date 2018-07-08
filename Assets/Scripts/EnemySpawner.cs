using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    
    [Range(0.1f, 10f)][SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] GameObject enemyToSpawn;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies() {
        while (true) {
            GameObject newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            newEnemy.transform.parent = transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
