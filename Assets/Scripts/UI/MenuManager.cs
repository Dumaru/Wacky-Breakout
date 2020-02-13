using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName menu)
    {

        switch (menu)
        {
            case MenuName.MAIN:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.HIGH_SCORE:
                // Deactivate the main menu
                GameObject mainMenuCanvas = GameObject.Find("MainMenuCanvas");
                mainMenuCanvas.SetActive(false);
                // Instantiate resource prefab
                Object.Instantiate(Resources.Load("HighScoreMenu"));
                break;
            case MenuName.HELP:
                // Deactivate the main menu
                GameObject mainMenu = GameObject.Find("MainMenuCanvas");
                mainMenu.SetActive(false);
                // Instantiate resource prefab
                Object.Instantiate(Resources.Load("HelpMenu"));
                break;
            case MenuName.DIFFICULTY:
                SceneManager.LoadScene("DifficultyMenu");
                break;
            case MenuName.PAUSE:
                Debug.Log("Pause case");
                // Instantiate resource prefab of pause menu
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
        }

    }
}