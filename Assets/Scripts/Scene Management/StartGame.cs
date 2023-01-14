using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    void Start()
    {
        Invoke("StartLevel",38);
        
    }

    public void StartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
