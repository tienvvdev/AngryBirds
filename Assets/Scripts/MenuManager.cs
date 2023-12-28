using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   
    public GameObject menuPanel;
    public GameObject levelsPanel;

    public LevelButton[] levelButtons;

    public GameObject[] lockButtons;

    private void Start()
    {
   
        SetMenuStars();

        
        DeactivateLockButtons();
    }

    
    private void DeactivateLockButtons()
    {
        
        int levelsSolved = PlayerPrefs.GetInt("levelsSolved", 0);

        for (int i = 0; i < levelsSolved; i++)
        {
            if (i < lockButtons.Length)
            {
                lockButtons[i].SetActive(false);
            }
        }
    }

    private void SetMenuStars()
    {

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelStars = PlayerPrefs.GetInt("level" + (i + 1) + "stars", 0);
            levelButtons[i].SetStars(levelStars);
        }
    }

    public void MenuToLevel()
    {
        menuPanel.gameObject.SetActive(false);
        levelsPanel.gameObject.SetActive(true);
    }

    public void LoadLevels(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}