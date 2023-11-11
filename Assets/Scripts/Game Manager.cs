using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    public static int score;
    
   
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
        
    }
    
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }
    
}
