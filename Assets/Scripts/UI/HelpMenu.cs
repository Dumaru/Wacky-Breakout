using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void HandleMainMenuButtonClicked()
    {
        MenuManager.GoToMenu(MenuName.MAIN);
        Destroy(this.gameObject);
    }
}