using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game instance;
    public static int difficulty = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play()
    {

    }

    public void NextLevel()
    {
        GameUI.instance.Disable(() => SceneManager.LoadScene("Game"));
        difficulty++;

        Debug.Log(difficulty);
    }

    public void BackOver()
    {
        ScoreData.Save(ScoreManager.scoreData);
        Back();
    }

    public void Back()
    {
        GameUI.instance.Disable(() => SceneManager.LoadScene("MainMenu"));
    }
}
