using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LucaController : MonoBehaviour
{
    public string Eri;
    public float movementspeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;

    public GameObject redsword;
    public GameObject magsword;
    public GameObject scythe;


    Rigidbody2D rb;
    Animator animator;
    Vector2 movement;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>() ;
    SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            redsword.SetActive(true);
            magsword.SetActive(false);
            scythe.SetActive(false);
        } 

        if(Input.GetKeyDown(KeyCode.T)){
            redsword.SetActive(false);
            magsword.SetActive(true);
            scythe.SetActive(false);
        } 

        if(Input.GetKeyDown(KeyCode.Y)){
            redsword.SetActive(false);
            magsword.SetActive(false);
            scythe.SetActive(true);
        } 
    }

    private void FixedUpdate() {
        if(movement != Vector2.zero){
            bool success = TryMove(movement);

            if(!success){
                success = TryMove(new Vector2(movement.x,0));
                if(!success){
                success = TryMove(new Vector2(0,movement.y));
                }
            }
            animator.SetBool("isWalking",success);
        }   else {
            animator.SetBool("isWalking", false);
            }

        if (movement.x < 0){
            spriteRender.flipX = true;
        } else if (movement.x > 0 ) {
            spriteRender.flipX = false;
        }  
    }

    private bool TryMove(Vector2 direction) { 
        int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                movementspeed * Time.fixedDeltaTime + collisionOffset);
    
        if (count == 0){
            rb.MovePosition(rb.position + direction * movementspeed * Time.fixedDeltaTime);
            return true; 
            } else { return false; 
        }
    }

    void OnMove(InputValue movementValue){
        movement = movementValue.Get<Vector2>();
    }

    /*private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "enemy") { 
            
        }
    }

    private void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.tag == "enemy") {
   
        }
    }*/
}

