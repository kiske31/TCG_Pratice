using UnityEngine;
using System.Collections;

public class LobbyUi : MonoBehaviour 
{
	public void GameExit () // 게임 엑시트 호출
    {
        Application.Quit();
	}
    
    public void ChangeScene(int sceneNum) // 로비에서 다른 씬으로 이동
    {
        SceneManager.Instance.ChangeScene(sceneNum);
    }
}
