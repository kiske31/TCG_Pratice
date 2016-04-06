using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour 
{
    private static SceneManager instance;

    public static SceneManager getInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new SceneManager();
            }
            return instance;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(int sceneNum)
    {
        Debug.Log(sceneNum);
        Application.LoadLevel(sceneNum);
    }
}
