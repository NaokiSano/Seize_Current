using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/* ===========================
 * プレイヤーのステータス関係 
 ========================== */

public class PlayerStatus : MonoBehaviour {

    public GameObject Text;
    public float hangryDamage;  // 腹減り度通常ダメージ
    public Hpbar hpBar;         // HPバー
    public Camera mainCamera;   // メインカメラ
    public EnemyManager enemyManager;
    public Text DangerText;     // 場外危険通知のテキスト
    public static int score;
    public GameObject RadarCanvas;  // レーダー
    public GameObject RadarMap;     // レーダー
    public Image Danger;        // 危険ゾーンテキストイメージ

    private GetMethod getMethod;    // 位置取得
    private Text HangryText;        // 腹減り度
    private PlayerMove playerMove;
    private float hangry;       // 腹減り度
    private bool deadFlag, timerF, deadType;      // 死亡フラグ、死亡タイマー、死亡タイプ
    private int nowLevel;       // 今の階層レベル
    float timer, deadTimer;     // 危険ゾーンタイマー、死亡タイマー

    void Awake()
    {
        //DontDestroyOnLoad(mainCamera);
    }

    // Use this for initialization
    void Start () {
        getMethod = GetComponent<GetMethod>();
        playerMove = this.GetComponent<PlayerMove>();
        HangryText = Text.GetComponent<Text>();
        DangerText = DangerText.GetComponent<Text>();
        DangerText.enabled = false;
        hangry = 150;   // 腹減り度MAX値150
        deadFlag = false;
        timerF = false;
        deadType = false;
        timer = 0;
        deadTimer = 0;
        Danger.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (timerF) return;

        if (deadFlag)  // 死亡フラグがたったら以下は処理しない
        {
            if(deadTimer <= 3)
            {
                if (deadType)
                {
                    RadarCanvas.SetActive(false);
                    RadarMap.SetActive(false);
                    deadTimer += 1 * Time.deltaTime;
                    GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.1f, 0), ForceMode.Impulse);
                    mainCamera.GetComponent<SmoothFollow>().SetDeadType(true);

                    float delta = Mathf.DeltaAngle(transform.eulerAngles.z, 90);
                    if (delta > 0)
                    {
                        transform.Rotate(new Vector3(0f, 0f, -1f));
                    }
                }
                else
                {
                    RadarCanvas.SetActive(false);
                    RadarMap.SetActive(false);
                    deadTimer += 1 * Time.deltaTime;
                    GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.1f, 0), ForceMode.Impulse);
                    mainCamera.GetComponent<SmoothFollow>().SetDeadType(true);
                    float delta = Mathf.DeltaAngle(transform.eulerAngles.z, 90);
                    if (delta > 0)
                    {
                        transform.Rotate(new Vector3(0f, 0f, -1f));
                    }
                }

            }
            else if(deadTimer <= 8)
            {
                deadTimer += 1 * Time.deltaTime;
                mainCamera.GetComponent<SmoothFollow>().SetFollowFlag(false);
            }
            else if( deadTimer > 8)
            {
                timerF = true;
                DangerText.text = "";
                SceneManager.LoadScene("Result", LoadSceneMode.Additive);
            }
            return;
        }

        if (hangry > 0) // 腹減りが0以上
        {
            HangryText.text = "腹減り度：" + (int)hangry;
            hangry -= hangryDamage * Time.deltaTime;
            hpBar.ChangeBar(hangry);

            if (hangry < 50)
            {
                AudioManager.Instance.PlaySE("playerEatBar");
            }
        }
        else
        {
            HangryText.text = "死亡";
            AudioManager.Instance.StopSE();
            getMethod.InitializeNowFloor();
            deadFlag = true;
            playerMove.ChangeMoveEnable(false); // 死亡で移動不能
            enemyManager.SetIsDead(true);
            getMethod.InitializeNowFloor();
            Cursor.visible = true;

            score = (int)this.transform.localScale.x;
        }
    }

    public static int GetScale()
    {
        return score;
    }

    /// <summary>
    ///  敵の大きさに応じて回復値を決定
    /// </summary>
    /// <param name="scale">敵のScale</param>
    /// <returns></returns>
    float RecoreryBrain(float scale)
    {
        int recovery = 0;
        if (scale <= 10)
        {
            recovery = 50;
        }
        else if (scale > 10 && scale <= 20)
        {
            recovery = 45;
        }
        else if (scale > 20 && scale <= 30)
        {
            recovery = 40;
        }
        else if (scale > 30 && scale <= 40)
        {
            recovery = 35;
        }
        return recovery;
    }

    /// <summary>
    ///  腹減り度回復
    /// </summary>
    /// <param name="enemyScale">敵の大きさ</param>
    public void RecoveryHangry(float enemyScale)
    {
        // 回復量を敵の大きさに応じて決定
        float recovery = RecoreryBrain(enemyScale); 
        recovery -= enemyScale; // 回復量 ─ 敵との大きさ
        hangry += recovery;     // その数値を回復
        if (hangry > 150)       // 最大値である150を超えたら
            hangry = 150;       // 最大値150に制限 
    }

    /// <summary>
    ///  腹減り度へダメージ
    /// </summary>
    /// <param name="damage">ダメージを与える数値</param>
    public void DamageHangry(float damage)
    {
        hangry -= damage;
    }

    /// <summary>
    ///  死亡フラグの取得
    /// </summary>
    /// <returns></returns>
    public bool GetSetDeadFlag
    {
       get { return deadFlag; }
       set { deadFlag = value; }
    }

    /// <summary>
    ///  死亡原因の設定
    /// </summary>
    /// <param name="flag">捕食されたならTrue</param>
    public void DeadType(bool flag)
    {
        deadType = flag;
    }

    /* ============= 壁 ============= */
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Wall")
        {
            DangerText.enabled = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag != "Wall")
        {
            return;
        }

        if(timer < 10)
        {
            timer += 0.5f * Time.deltaTime;
            Danger.enabled = true;
            DangerText.text = " : " + (10 - (int)timer);
        }
        else
        {
            hangry = 0;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Wall")
        {
            timer = 0;
            DangerText.enabled = false;
            Danger.enabled = false;
        }
    }
}
