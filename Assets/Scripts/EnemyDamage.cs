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
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDieSFX;

    private Transform deathParticleParent;
    private Transform enemyHitParticleParent;
    private ScoreUpdater scoreUpdater;
    private EnemyCountUpdater enemyCountUpdater;
    private AudioSource audioSource;

    void Start() {
        SetDeathParticleParent();
        scoreUpdater = FindObjectOfType<ScoreUpdater>();
        enemyCountUpdater = FindObjectOfType<EnemyCountUpdater>();
        audioSource = GetComponent<AudioSource>();
    }

    void SetDeathParticleParent() {
        deathParticleParent = GameObject.Find("Enemy Death Particles").transform;
        enemyHitParticleParent = GameObject.Find("Enemy Hit Particles").transform;
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

        AudioSource.PlayClipAtPoint(enemyDieSFX, FindObjectOfType<Camera>().transform.position, audioSource.volume);
        HandleDeathParticleSystem();
        scoreUpdater.IncrementScore(1);
        enemyCountUpdater.AdjustEnemyCount(-1);
        Destroy(gameObject);
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
            CreateHitParticle();
            audioSource.PlayOneShot(enemyHitSFX);
        }        
    }

    private void CreateHitParticle() {
        ParticleSystem newHitPS = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity);
        newHitPS.transform.parent = enemyHitParticleParent;
        newHitPS.Play();
        Destroy(newHitPS.gameObject, 1f);
    }

    private bool IfKilled() {
        return hitPoints <= 0;
    }
}
