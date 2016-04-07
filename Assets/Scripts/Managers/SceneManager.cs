using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour 
{
    private static SceneManager instance;

    public static SceneManager Instance
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

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(int sceneNum)
    {
        Application.LoadLevel(sceneNum);
    }
}
