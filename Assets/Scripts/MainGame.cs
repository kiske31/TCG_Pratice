using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainGame : MonoBehaviour 
{
    public Text timeCount;
    public static bool g_StartGame = false;
    public static bool g_MyTurn = true;
    public static int g_TurnCount = 1;
    public static int g_TimeCount = 60;

    float time;

    void Awake()
    {
        time = g_TimeCount;
    }

    void Update()
    {
      
    }

    void Timer()
    {
        time -= Time.deltaTime;
        g_TimeCount = (int)time;
        timeCount.text = g_TimeCount.ToString();
    }
}
