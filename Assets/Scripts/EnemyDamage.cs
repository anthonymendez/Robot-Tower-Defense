using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (IfKilled()) {
            ParticleSystem deathParticles = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            deathParticles.Play();
            Destroy(gameObject);
        }
    }

    private void ProcessHit() {
        if (hitPoints > 0) {
            hitPoints--;
            hitParticlePrefab.Play();
        }        
    }

    private bool IfKilled() {
        return hitPoints <= 0;
    }
}
