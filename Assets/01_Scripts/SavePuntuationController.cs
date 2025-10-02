using UnityEngine;
using UnityEngine.UI;

public class SavePuntuationController : MonoBehaviour
{
    [Header("Puntuation Settings")]
    [SerializeField] private int score;

    [Header("References")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreTextA;
    [SerializeField] private Text scoreTextB;
    [SerializeField] private Text scoreTextMainMenu;

    void Start()
    {
        DisplayHighScore();
    }
  
    void Update()
    {
        HandlerPuntuation();
    }

    public void SavePuntuation (int pointA, int pointB)
    {
        int currentPoints = PlayerPrefs.GetInt("HighScore");

        if (pointA > currentPoints)
        {
            PlayerPrefs.SetInt("HighScore", pointA);

        } 
        else if (pointB > currentPoints) 
        {
            PlayerPrefs.SetInt("HighScore", pointB);
        }
        else 
        {
            PlayerPrefs.SetInt("HighScore", currentPoints);
        }
    }

    void HandlerPuntuation()
    {
        SavePuntuation(score, score);
    }

    void DisplayHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");

        if (scoreTextMainMenu != null)
        {
            scoreTextMainMenu.text = highScore.ToString();
        } 
        else
        {
            scoreText.text = highScore.ToString();
        }
    }
}
