using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text score_text;
    public GameObject score_screen;
    public GameObject start_screen;
    public int high_score;
    public Text high_score_text;

    private void Start()
    {
        score = 0;
        score_text.text = score.ToString();
        score_text.gameObject.SetActive(false);
        
        high_score = PlayerPrefs.GetInt("HighScore", 0);
        high_score_text.text = "High Score: " + high_score.ToString();
        high_score_text.gameObject.SetActive(false);

    }

    

    public void update_score()
    {
        
        score++;
        score_text.text = score.ToString();
        if (score > high_score)
        {
            high_score = score;
            high_score_text.text = "High Score: " + high_score.ToString();
            PlayerPrefs.SetInt("HighScore", high_score); 
        }
    }
    public void restart_game()
    {
        SceneManager.LoadScene(0);
    }
}
