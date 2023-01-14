using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aerusSpawner : MonoBehaviour
{
    public GameObject[] aerus;
    public Transform spawnPoint;

    public bool isDefeated;


    private void Start(){
        Invoke("summonAerus()",3);
        isDefeated = false;
    }

    public void summonAerus(){
        Instantiate(aerus[0], spawnPoint.transform.position, Quaternion.identity);
    } 

    public void Update(){
        if (isDefeated){
            Instantiate(aerus[1], spawnPoint.transform.position, Quaternion.identity);
        } 
    }
}
