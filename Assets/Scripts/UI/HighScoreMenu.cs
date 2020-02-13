using UnityEngine;

public class HighScoreMenu : MonoBehaviour {
    public void HandleMainMenuButtonClicked(){
        MenuManager.GoToMenu(MenuName.MAIN);
        Destroy(this.gameObject);
    }
}