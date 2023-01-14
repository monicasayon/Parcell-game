using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool Win;

    private void Awake()
    {
        isGameOver = false;
        Win = false;
    }

    void Start(){
    }

    void Update()
    {
        if (isGameOver) {
            SceneManager.LoadScene(3);
        }
        if (Win) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
