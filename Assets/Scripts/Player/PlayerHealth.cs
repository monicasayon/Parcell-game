using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image Bar;
    public float playerHealth = 100f;
    public static bool isDamaged;

    private void Start() {
        isDamaged = false;
    }

    void Update() {
        if (isDamaged) {
            TakeDamage(5f);
        }

        if(playerHealth <= 0) {
            PlayerManager.isGameOver = true;
        }
    }

    public void TakeDamage(float damage) {
        playerHealth -= damage * Time.fixedDeltaTime;
        Bar.fillAmount = playerHealth / 100f;
    }
}

