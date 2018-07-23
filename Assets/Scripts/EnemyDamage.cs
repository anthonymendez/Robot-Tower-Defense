using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    private Transform deathParticleParent;

    void Start() {
        SetDeathParticleParent();
    }

    void SetDeathParticleParent() {
        deathParticleParent = GameObject.Find("Enemy Death Particles").transform;
    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (IfKilled()) {
            if (deathParticleParent == null) {
                SetDeathParticleParent();
            }

            HandleDeathParticleSystem();
            Destroy(gameObject);
        }
    }

    private void HandleDeathParticleSystem() {
        ParticleSystem deathParticles = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathParticles.transform.parent = deathParticleParent;
        deathParticles.Play();
        Destroy(deathParticles.gameObject, deathParticles.main.duration);
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
