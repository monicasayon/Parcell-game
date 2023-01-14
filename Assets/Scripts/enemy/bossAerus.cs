using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAerus : MonoBehaviour
{
    public GameObject aerus1;
    public GameObject aerus2;

    public static bool firstIsDead = false;
    public static bool secondIsDead = false;

    Animator anim;

    void Start()
    {   
        anim = GetComponent<Animator>();
        
    }

    public void Update(){
        if(firstIsDead) {
            Invoke("firstDead",1);
            Invoke("secondAttack",3);
        }

        if(secondIsDead) {
            Invoke("secondDead",2);
        }
    }

    private void firstDead(){
        aerus1.SetActive(false);
    }

    private void secondDead(){
        aerus2.SetActive(false);
        PlayerManager.Win = true;
    }


    private void secondAttack(){
        anim.SetBool("isAttacking", true);
        aerus2.SetActive(true);
    }

    public void firstAttack()
    {
        anim.SetBool("isAttacking", true);
        aerus1.SetActive(true);
    }
    

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player") {
            Invoke("firstAttack",5);
        }
    }
}
