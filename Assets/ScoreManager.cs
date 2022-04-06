using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreData scoreData = new ScoreData();
    public static int score
    {
        set
        {
            scoreData.score = value;
            onScoreUpdate.Invoke(score);
        }
        get => scoreData.score;
    }

    public static UnityEvent<int> onScoreUpdate = new UnityEvent<int>();
}
