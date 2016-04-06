using UnityEngine;
using System.Collections;


public class SaveDataManager : MonoBehaviour
{
    private static SaveDataManager instance;

    public static SaveDataManager getInstance
    {
        get
        {
          if (instance == null)
           {
                instance = new SaveDataManager();
           }
        return instance;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
