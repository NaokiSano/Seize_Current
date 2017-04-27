using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("GameManager/ManageScript")]

public sealed class GameManager : MonoBehaviour {

    public EnemyManager EnemyManagerScript;   // エネミー管理マネージャー
    public EnemyScaler EnemyScaler;     // エネミースケール管理

    [SerializeField, HeaderAttribute("ステージ階層[3]")]
    public GameObject[] StageKaisou;

    private GameQuit GameQuit;           // ゲーム終了
    int nowLevel;   // 今の階層情報
    
    void Awake()
    {
        nowLevel = 0;
    }

	// Use this for initialization
	void Start () {
        GameQuit = this.GetComponent<GameQuit>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    ///  今のステージ階層を取得、設定する
    /// </summary>
    public int GetSetNowLevel
    {
        set
        {
            nowLevel = value;
            EnemyManagerScript.SetLevel(nowLevel);
        }
        get { return nowLevel; }
    }


    
}
