using UnityEngine;
using System.Collections;

public class LobbyUi : MonoBehaviour 
{
	public void GameExit () 
    {
        Application.Quit();
	}
    
    public void ChangeScene(int sceneNum)
    {
        SceneManager.Instance.ChangeScene(sceneNum);
    }
}
