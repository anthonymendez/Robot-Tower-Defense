using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int healthPoints = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] List<Text> healthTexts;
    [SerializeField] AudioClip playerDamageSFX;

    void Start() {
        UpdateHealthTexts();
    }

    private void UpdateHealthTexts() {
        foreach (Text healthText in healthTexts) {
            healthText.text = healthPoints.ToString();
        }
    }

    void OnTriggerEnter(Collider collider) {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        healthPoints -= healthDecrease;
        UpdateHealthTexts();
    }
}
