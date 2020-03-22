using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    void Start()
    {
        // Pauses the game
        AudioManager.Play(AudioClipName.GAME_OVER);
        Time.timeScale = 0;
        textMesh.text = "Score: " + GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().Score;
    }

    public void HandleResumeButtonClicked()
    {
        // Resumes the game time
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }
    public void HandleMainMenuButtonClicked()
    {
        // Resumes the game time
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.MAIN);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
