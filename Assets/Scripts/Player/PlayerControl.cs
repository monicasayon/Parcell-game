using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public string Eri;
    //public float health=100f;
    //public bool isDamaged=false;
    //public bool isWalking=false;
    public float movementspeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;
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


    public void FixedUpdate() {
        if(movement != Vector2.zero){
            bool success = TryMove(movement);

            if(!success){
                success = TryMove(new Vector2(movement.x,0));
                if(!success){
                success = TryMove(new Vector2(0,movement.y));
                }
            }

        animator.SetBool("isWalking", success);
        } else {
        animator.SetBool("isWalking", false);
        }

        if (PlayerManager.isGameOver == true) {
          TryMove(new Vector2(0,0));
        }

        if(movement.x < 0) {
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
}

