using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int healthPoints = 10;
    [SerializeField] int healthDecrease = 1;

	void OnTriggerEnter(Collider collider) {
        healthPoints -= healthDecrease;
    }
}
