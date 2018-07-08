using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy; // TODO Change based on enemy.
	
	// Update is called once per frame
	void Update () {
        objectToPan.LookAt(targetEnemy);
	}
}
