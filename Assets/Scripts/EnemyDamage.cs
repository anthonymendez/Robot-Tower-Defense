using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour {
    
    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] List<Text> scoreTexts;

    private Transform deathParticleParent;
    private ScoreUpdater scoreUpdater;

    void Start() {
        SetDeathParticleParent();
        scoreUpdater = FindObjectOfType<ScoreUpdater>();
    }

    void SetDeathParticleParent() {
        deathParticleParent = GameObject.Find("Enemy Death Particles").transform;
    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (IfKilled()) {
            HandleEnemyKilled();
        }
    }

    private void HandleEnemyKilled() {
        if (deathParticleParent == null) {
            SetDeathParticleParent();
        }

        HandleDeathParticleSystem();
        IncrementScore();
        Destroy(gameObject);
    }

    private void HandleDeathParticleSystem() {
        ParticleSystem deathParticles = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathParticles.transform.parent = deathParticleParent;
        deathParticles.Play();
        Destroy(deathParticles.gameObject, deathParticles.main.duration);
    }

    private void IncrementScore() {
        scoreUpdater.IncrementScore(1);
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
