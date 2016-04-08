using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameUi : MonoBehaviour 
{
    public Button menuButton;
    public GameObject menuUi;

    public void MenuPanelShow() // 메뉴 패널을 열고 게임을 퍼즈 
    {                           // TODO : 게임 퍼즈 미구현
        if (!menuUi.active)
        {
            menuUi.SetActive(true);
        }

        menuButton.interactable = false;
    }

    public void RetryGame() // TODO : 게임을 재시작 한다.
    {
    }

    public void GoToLobby() //  로비로 돌아간다.
    {
        SceneManager.Instance.ChangeScene(0);
    }

    public void MenuPanelShowOff() // 메뉴 패널을 닫고 게임을 다시 진행
    {
        menuButton.interactable = true;

        if (menuUi.active)
        {
            menuUi.SetActive(false);
        }
    }
}
