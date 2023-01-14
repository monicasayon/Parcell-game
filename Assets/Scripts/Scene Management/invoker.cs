using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class invoker : MonoBehaviour
{

    void Start()
    {
        Invoke("bossFight",5);
    }

    public void bossFight(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
