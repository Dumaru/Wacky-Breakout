using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Pauses the game
        Time.timeScale = 0;
    }

    public void HandleResumeButtonClicked(){
        // Resumes the game time
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }
    public void HandleMainMenuButtonClicked(){
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
