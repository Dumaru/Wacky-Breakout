using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandlePlayButtonClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void HandleDifficultyButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.DIFFICULTY);
    }
    public void HandleHighScoreButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.HIGH_SCORE);
    }
    public void HandleHelpButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.HELP);

    }

    public void HandleQuitButtonClicked()
    {
        Application.Quit();
    }
}
