using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swordAttack : MonoBehaviour
{
    public Transform target;
    Animator anim;
    public float minDistance;
    //public static bool onHit;

    public float knockbackDuration = 100f;
    public float knockbackPower = 1f;

    void Start()
    {
        anim = GetComponent<Animator>();
        target = GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
       if(other.gameObject.tag == "enemy") {
            if(Input.GetKeyDown(KeyCode.Space)) {
                anim.SetBool("isAttacking",true);
                enemyHealth.isHit = true;
                StartCoroutine(bossChase.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
            } 
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "enemy") {
            if(Input.GetKeyDown(KeyCode.Space)) {
                anim.SetBool("isAttacking",true);
                enemyHealth.isHit = true;
                StartCoroutine(bossChase.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
            } 
            
        }
            //Debug.Log("Swing swing!");
            //target = other.transform;
            
    }

    private void OnCollisionExit2D(Collision2D other) {
       if (other.gameObject.tag == "enemy") {
            target = null;
            enemyHealth.isHit = false;
            //onHit = false;
       } 
    }
}

