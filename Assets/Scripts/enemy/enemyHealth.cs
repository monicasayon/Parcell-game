using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyHealth : MonoBehaviour
{
    public Image Bar;
    private float enemyHP = 100f;
    public static bool isHit;

    private void Start() {
        isHit = false;
    }

    public void Update() {
        if(isHit){
            TakeDamage(50f);
        }
       
        if(enemyHP <= 0) {
            enemyHP = 0;
            PlayerManager.Win = true;
        }
    }

    public void TakeDamage(float damage) {
        enemyHP -= damage * Time.fixedDeltaTime;
        Bar.fillAmount = enemyHP / 100f;
    }   
}

