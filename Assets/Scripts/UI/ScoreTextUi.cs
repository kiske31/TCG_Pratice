using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTextUi : MonoBehaviour {

    public Text playerWin;
    public Text enemyWin;
    public Text destroyCard;
    public Text drawCard;
    public Text totalDamage;

    void Awake()
    {
        playerWin.text = "PlayerWin : " + SaveDataManager.Instance.LoadData(0).ToString();
        enemyWin.text = "EnemyWin : " + SaveDataManager.Instance.LoadData(1).ToString();
        destroyCard.text = "Destroyed Card : " + SaveDataManager.Instance.LoadData(2).ToString();
        drawCard.text = "Draw Card : " + SaveDataManager.Instance.LoadData(3).ToString();
        totalDamage.text = "Damage to Uhm : " + SaveDataManager.Instance.LoadData(4).ToString(); 
    }

    public void ExitToLobby()
    {
        SceneManager.Instance.ChangeScene(0);
    }
}
