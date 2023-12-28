using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverPanel;
    public Image[] stars;
    public Sprite yellowStar;
    public bool gameIsOver;


    private void LevelStarsCount(int levelIndex, int stars)
    {

        if (PlayerPrefs.GetInt("level" + levelIndex + "stars", 0) < stars)
        {
            PlayerPrefs.SetInt("level" + levelIndex + "stars", stars);
        }
    }

    public void GameOver()
    {

        gameIsOver = true;
        gameOverPanel.gameObject.SetActive(true);


        int currentLevel = SceneManager.GetActiveScene().buildIndex;


        if (Enemy.enemiesAlive <= Enemy.maxEnemies * 2 / 3)
        {
            stars[0].sprite = yellowStar;
            LevelStarsCount(currentLevel, 1);
        }

        if (Enemy.enemiesAlive <= Enemy.maxEnemies * 0.5f)
        {
            stars[1].sprite = yellowStar;

            LevelStarsCount(currentLevel, 2);
        }


        if (Enemy.enemiesAlive == 0)
        {
            stars[2].sprite = yellowStar;


            LevelStarsCount(currentLevel, 3);

            if (currentLevel > PlayerPrefs.GetInt("levelsSolved", 0))
            {
                PlayerPrefs.SetInt("levelsSolved", currentLevel);
            }

        }
    }

    void Update()
    {
      
        if (Enemy.enemiesAlive == 0 && gameIsOver == false)
        {
            GameOver();
        }
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Enemy.enemiesAlive = 0;
        Enemy.maxEnemies = 0;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        Enemy.enemiesAlive = 0;
        Enemy.maxEnemies = 0;
    }
}