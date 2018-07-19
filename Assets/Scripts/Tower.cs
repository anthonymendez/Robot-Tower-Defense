using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    //Parameters
    [Header("Tower Properties")]
    [SerializeField] float maxFiringDistance = 10f;

    [Header("Targeting Properties")]
    [SerializeField] Transform objectToPan;
    
    [Header("Components")]
    [SerializeField] ParticleSystem bulletParticleSystem;

    // States
    private Transform targetEnemy; // TODO Change based on enemy.

    public Node baseNode;
	
    // Update is called once per frame
	void Update () {
        SetTargetEnemy();
        if (targetEnemy && IsEnemyWithinRange()) {
            objectToPan.LookAt(targetEnemy);
            Shoot(true);
        } else {
            Shoot(false);
        }
	}

    // Targets the closest enemy
    private void SetTargetEnemy() {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();

        if (sceneEnemies.Length == 0)
            return;

        int closestEnemyIndex = 0;
        float closestEnemyDistance = Vector3.Distance(sceneEnemies[0].transform.position, transform.position);
        for (int currentIndex = 1; currentIndex < sceneEnemies.Length; currentIndex++) {
            float currentIndexEnemyDistance = Vector3.Distance(sceneEnemies[currentIndex].transform.position, transform.position);

            if(currentIndexEnemyDistance < closestEnemyDistance) {
                closestEnemyDistance = currentIndexEnemyDistance;
                closestEnemyIndex = currentIndex;
            }
        }

        targetEnemy = sceneEnemies[closestEnemyIndex].transform;
    }

    private bool IsEnemyWithinRange() {
        float distanceToEnemy = Vector3.Distance(objectToPan.position, targetEnemy.position);
        return maxFiringDistance >= distanceToEnemy;
    }

    private void Shoot(bool isActive) {
        ParticleSystem.EmissionModule emissionModule = bulletParticleSystem.emission;
        emissionModule.enabled = isActive;
    }
}
