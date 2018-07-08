using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 10;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (IfKilled()) {
            Destroy(gameObject);
        }
    }

    private void ProcessHit() {
        if (hitPoints > 0) {
            hitPoints--;
            print(String.Format("Enemy HP:{0}", hitPoints));
        }        
    }

    private bool IfKilled() {
        return hitPoints <= 0;
    }
}
