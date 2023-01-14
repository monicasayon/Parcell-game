using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossChase : MonoBehaviour
{
    public static bossChase instance;

    public float speed = 2f;
    public bool killPlayer = false;
    public float minDistance = 1f;
    [SerializeField] public float attackSpeed = 1f;
    [SerializeField] public float attackDamage = 10f;
    public float canAttack;
    public Transform target;
    Animator animator;
    Rigidbody2D rb;

    void Awake(){
        instance = this;
    }

    void Start(){
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
   }

    public void Update(){
        if  (target != null) {
            if (Vector2.Distance(transform.position, target.position) > minDistance) {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
                animator.SetBool("isChasing",true);
            } else if (Vector2.Distance(transform.position, target.position) > minDistance) {
                animator.SetBool("isAttacking",true);
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            animator.SetBool("isAttacking",true);
            PlayerHealth.isDamaged = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            animator.SetBool("isAttacking",false);
            PlayerHealth.isDamaged = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if (other.gameObject.tag == "Player") {
        target = other.transform;
        animator.SetBool("isChasing", true);
       } 
    }

    private void OnTriggerExit2D(Collider2D other) {
       if (other.gameObject.tag == "Player") {
        target = null;
        animator.SetBool("isChasing", false);
       } 
    }

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj){
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        } 

        yield return 0;
    }
}

