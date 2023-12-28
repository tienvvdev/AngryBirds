using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    
    public Image[] starsImages;
    public Sprite yellowStar;

    
    public void SetStars(int stars)
    {
        
        for (int i = 0; i < stars; i++)
        {
            starsImages[i].sprite = yellowStar;
        }
    }
}