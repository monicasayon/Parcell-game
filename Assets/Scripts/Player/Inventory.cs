using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Inventory : MonoBehaviour
{
    public Text oxygenCounter;
    public Text carbonCounter; 

    private int oxygens = 0;
    private int carbons = 0;

    public int itemsRemaining;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Collectibles")){
            Collect(other.GetComponent<Collectibles>());
        }
    }

    private void Collect(Collectibles collectibles){
        if(collectibles.Collect()){
            if(collectibles is CarbonCollect){
                oxygens++;
            } else if(collectibles is OxygenCollect){
                carbons++;
            }
            UpdateGUI();
            itemsRemaining--;
        }
    }

    private void Update(){
        if(itemsRemaining <= 0){
            itemsRemaining = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void UpdateGUI(){
        oxygenCounter.text = oxygens.ToString();
        carbonCounter.text = carbons.ToString();
    }
    
}

