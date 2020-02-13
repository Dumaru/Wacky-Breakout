using UnityEngine;

public class DifficultyMenu : MonoBehaviour
{
    public void HandleMainMenuButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.MAIN);
        Destroy(this.gameObject);
    }
}