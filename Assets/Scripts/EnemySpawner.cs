using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] int amountOfEnemiesToSpawn = 10;
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] GameObject enemyToSpawn;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies() {
        while (true) {
            GameObject newEnemy = Instantiate(enemyToSpawn);
            newEnemy.transform.parent = transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
