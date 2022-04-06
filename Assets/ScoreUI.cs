using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Start()
    {
        ScoreManager.onScoreUpdate.AddListener(UpdateText);
        UpdateText();
    }

    public void UpdateText(int value = 0)
    {
        scoreText.text = ScoreManager.score.ToString();
    }
}
