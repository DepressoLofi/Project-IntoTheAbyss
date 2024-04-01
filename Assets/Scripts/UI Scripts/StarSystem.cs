using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarSystem : MonoBehaviour
{
    public TextMeshProUGUI starText;
    public int starCount = 0;

    void Start()
    {
        UpdateScore();
    }

    public void IncreaseStarCount(int starCollected)
    {
        starCount = starCollected;
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (starText != null)
        {
            starText.text = "Star: " + starCount.ToString();
        }
    }
}
