using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public bool DebugLog;
    public Text text;
    public float spawnTime = 3f;
    public GameObject[] enemy;      //enemyの種類を入れる
    public GameManager gameManager;

    bool isDead;
    ArrayList spawnP;               // 可変長配列(階層毎に、SpawnPointの数は違うため)
    public GameObject[] SpawnPointsParent;  // spawnPointの階層
    public GetMethod PlayerPos;   // Player
    int now, old, spawnCount;                      // 過去階層情報保存変数, スポーン数
    int spawnIndex;               // 表示する場所
    Transform[] startList;        // ゲームスタート時の生成配列
    public GameObject enemyParent;

    void Start()
    {
        isDead = false;
        FirstSpawn();

        old = 10;    // 最初は１から(本来は配列0からだけど、わざと相違させてリスト追加を行う)
        spawnP = new ArrayList();

        //リピート処理
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    public void Update()
    {
        int nownow = gameManager.GetSetNowLevel + 1;
        text.text = "Stage：" + nownow;

        if (isDead) spawnTime = 10;
    }

    public void SetLevel(int level)
    {
        now = level;
    }
    public int GetLevel()
    {
        return now;
    }

    /// <summary>
    ///  初期処理、第0階層全てののSpawnPointから一体ずつ生成   
    /// </summary>
    void FirstSpawn()
    {
        // 0階層目のSpawnPointのサイズで配列実体を生成
        startList = new Transform[SpawnPointsParent[0].transform.childCount];

        // その配列を回して、一箇所につき一匹ずつ生成していく
        for (int i = 0; i < startList.Length; i++)
        {
            startList[i] = SpawnPointsParent[0].transform.GetChild(i);
            GameObject newEnemy = Instantiate(enemy[Random.Range(0, enemy.Length)], startList[i].transform.position, startList[i].rotation) as GameObject;
            newEnemy.transform.parent = GameObject.Find("Enemies").transform;
            spawnCount++;
        }
        
    }

    //Enemyの生成
    void Spawn()
    {
        int spawnPointIndex = GetSpawnPoint();  // どこで生成するかのIndex番号
        Transform[] list = copyList(spawnP);    // ArrayのspawnP内の各Transformをコピー

        // GetSpawnPointで選ばれた場所にプレイヤーがいたら、ここまでループする
        if(list[spawnPointIndex].GetComponent<SpawnPoint>().isHitFlg())
        {
            return;
        }

        // 上のループを抜けたら生成 
        GameObject now = Instantiate(enemy[Random.Range(0, enemy.Length)], list[spawnPointIndex].position, list[spawnPointIndex].rotation) as GameObject;
        //int max = PlayerPos.GetSetFloor + 1;
        //int scale = Random.Range(max, max*10);

        //Vector3 vec = new Vector3(scale, scale, scale);
        //now.transform.localScale = vec;
        spawnCount++;

        if (spawnCount >= 100)
        {
            spawnTime = 10;
        }
        else
        {
            spawnTime = 3;
        }
    }

    // 階層のSpawnPointを取得
    int GetSpawnPoint()
    {
        // 今の階層情報を取得する
        // (階層情報は1から。それを0からにして代入する為、-1する)
        //now = PlayerPos.GetSetFloor;
        //Debug.Log("階層："+now);
        if (DebugLog)
        {   // デバッグ表示
            Debug.Log("now：" + now);
            Debug.Log("past：" + old);
        }

        // 過去の階層情報と照らし合わせて、違うなら配列クリアで次へ
        if (old != now)
        {
            if(DebugLog) Debug.Log("リストクリアNext");
            if(DebugLog) Debug.Log("Next");
            spawnP.Clear();

            int nowEnemyCount = enemyParent.transform.childCount;
            if (nowEnemyCount > 20)
            {
                int deleteCount = Mathf.Abs(20 - nowEnemyCount);
                Debug.Log(deleteCount);
                for (int i = 0; i < deleteCount; i++)
                {
                    Destroy(enemyParent.transform.GetChild(i).gameObject);
                }
            }
        }
        else // 階層が変わってないなら、配列はそのままでindexだけRandom処理して終了
        {
            if(DebugLog) Debug.Log("リターン");
            spawnIndex = Random.Range(0, spawnP.Count);
            return spawnIndex;
        }

        old = now;  //今の階層情報を保存

        // その今の階層情報ごとのSpawnPointsを生成配列に代入
        for (int i = 0; i < SpawnPointsParent[now].transform.childCount; i++)
        {
            spawnP.Add(SpawnPointsParent[now].transform.GetChild(i));
        }

        //if (DebugLog) Debug.Log("要素数："+spawnP.Count);

        // ランダムIndexを、spawnPの要素数から作成
        spawnIndex = Random.Range(0, spawnP.Count);
        return spawnIndex; 
    }

    /// <summary>
    ///  ArrayListからGameObject[]への変換
    /// </summary>
    /// <param name="array">SpawnPointが入ったArrayList</param>
    /// <returns>変換後配列</returns>
    Transform[] copyList(ArrayList array)
    {
        Transform[] nowList = new Transform[array.Count];
        array.CopyTo(nowList);
        return nowList;
    }

    public void SetIsDead(bool flag)
    {
        isDead = flag;
    }
}
