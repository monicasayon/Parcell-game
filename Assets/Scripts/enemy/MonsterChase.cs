using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    public float speed = 2f;
    public float minDistance;
    public bool killPlayer = false;

    public Transform target;
    Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
   }

    public void Update(){
        if  (target != null) {
            if (Vector2.Distance(transform.position, target.position) > minDistance) {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            } else if (Vector2.Distance(transform.position,target.position) <= minDistance) {
                animator.SetBool("isAttacking",true);
                PlayerManager.isGameOver = true;
            }
        }      
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            PlayerManager.isGameOver = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
       if (other.gameObject.tag == "Player") {
        target = other.transform;
        Debug.Log("Entered!");
       } 
    }

    private void OnTriggerExit2D(Collider2D other) {
       if (other.gameObject.tag == "Player") {
        target = null;
        animator.SetBool("isAttacking", false);
       } 
    }
}
