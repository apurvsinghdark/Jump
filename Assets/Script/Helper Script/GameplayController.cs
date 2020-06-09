using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Text scoreText;

    private int score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = " X " + score;
    }

    public void Restart()
    {
        Invoke("ReloadGame", 3f);
    }
    void ReloadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
