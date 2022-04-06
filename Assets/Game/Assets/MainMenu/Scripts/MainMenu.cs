using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public UIMainMenu uiMainMenu;
    public UIHighScore uiHighScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartGame()
    {
        uiMainMenu.uiED.ActionDisable(() => SceneManager.LoadScene("Game"));
        ScoreManager.score = 0;
    }

    public void OnHighScore()
    {
        uiHighScore.uiED.ActionEnable(() => Debug.Log("OnHighScore"));
    }

    public void OnExitGame()
    {
        uiMainMenu.uiED.ActionDisable(Application.Quit);
    }
}
