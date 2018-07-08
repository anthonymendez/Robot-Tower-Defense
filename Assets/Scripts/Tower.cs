using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [Header("Tower Properties")]
    [SerializeField] float maxFiringDistance = 10f;

    [Header("Targeting Properties")]
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy; // TODO Change based on enemy.

    [Header("Components")]
    [SerializeField] ParticleSystem bulletParticleSystem;

	// Update is called once per frame
	void Update () {
        if (targetEnemy && IsEnemyWithinRange()) {
            objectToPan.LookAt(targetEnemy);
            Shoot(true);
        } else {
            Shoot(false);
        }
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
