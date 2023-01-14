using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public static bomb instance;
    public float speed = 5f;
    public Transform target;
    //Animator animator;
    Rigidbody2D rb;

    void Start(){
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        instance = this;
   }

    public void Update(){
        if  (target != null) {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
                //animator.SetBool("isChasing",true);
            } else {
                //animator.SetBool("isAttacking",true);
            }
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            PlayerManager.isGameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if (other.gameObject.tag == "Player") {
        target = other.transform;
        cocobomber.isThrown = true;
       } 
    }

    private void OnTriggerExit2D(Collider2D other) {
       if (other.gameObject.tag == "Player") {
        target = null;
        //animator.SetBool("isChasing", false);
       } 
    }

}