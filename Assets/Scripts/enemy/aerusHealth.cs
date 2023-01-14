using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class aerusHealth : MonoBehaviour
{
    
    public Image Bar;
    private float aerusHP = 100f;
    public static bool isHit;

    private void Start() {
        isHit = false;
    }

    public void Update() {
        if(isHit){
            TakeDamage(25f);
        }

        if(aerusHP <= 50){
            bossAerus.firstIsDead = true;
        }
        
        if(aerusHP <= 0) {
            aerusHP = 0;
            bossAerus.secondIsDead = true;
        }
    }

    public void TakeDamage(float damage) {
        aerusHP -= damage * Time.fixedDeltaTime;
        Bar.fillAmount = aerusHP / 100f;

        
    }   
}

