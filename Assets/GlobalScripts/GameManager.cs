using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int score;

    public Text scoreText;
    public GameObject gameoverCanvas;
    
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
        score = 0;
        Time.timeScale = 1;
    }

    public static void AddScore(int amount)
    {
        score += amount;
        instance.scoreText.text = score.ToString();
    }

    public static void PlayerDie()
    {
        Time.timeScale = 0;
        instance.gameoverCanvas.SetActive(true);
    }

}
