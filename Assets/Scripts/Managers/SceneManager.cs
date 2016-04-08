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
            if (instance == null)
            {
                GameObject obj = new GameObject("SceneManager");
                instance = obj.AddComponent(typeof(SceneManager)) as SceneManager;
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(int sceneNum)
    {
        Application.LoadLevel(sceneNum);
    }
}
