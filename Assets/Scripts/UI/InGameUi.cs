using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameUi : MonoBehaviour 
{
    public Button menuButton;
    public GameObject menuUi;

    public void MenuPanelShow()
    {
        if (!menuUi.active)
        {
            menuUi.SetActive(true);
        }

        menuButton.interactable = false;
    }

    public void RetryGame()
    {

    }

    public void GoToLobby()
    {
        SceneManager.Instance.ChangeScene(0);
    }

    public void MenuPanelShowOff()
    {
        menuButton.interactable = true;

        if (menuUi.active)
        {
            menuUi.SetActive(false);
        }
    }
}
