using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    
    [Range(0.1f, 10f)][SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] AudioClip spawnedEnemySFX;

    private EnemyCountUpdater enemyCountUpdater;

	// Use this for initialization
	void Start () {
        enemyCountUpdater = FindObjectOfType<EnemyCountUpdater>();
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies() {
        while (true) {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            GameObject newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            newEnemy.transform.parent = transform;
            enemyCountUpdater.AdjustEnemyCount(1);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
