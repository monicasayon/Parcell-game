using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cocobomber : MonoBehaviour
{
    
    public GameObject cocoBomb;
    public static bool isThrown = false;
    //Animator anim;

    void Start()
    {   
        //anim = GetComponent<Animator>();
        isThrown = false;
    }

    public void Update(){
        if(isThrown) {
            Invoke("Throw",2);
        }
    }

    public void Throw() {
        cocoBomb.SetActive(true);
    }

    public void Explode() {
        cocoBomb.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player") {
        }
    }
}