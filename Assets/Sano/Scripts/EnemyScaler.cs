using UnityEngine;
using System.Collections;

public class EnemyScaler : MonoBehaviour {

    private GameManager GetPlayerPos;
    int nowLevel, baseLevel;

	// Use this for initialization
	void Start () {
        baseLevel = 0;  // 0階層から
        GetPlayerPos = GameObject.Find("GameManager").GetComponent<GameManager>();
        nowLevel = GetPlayerPos.GetSetNowLevel;
        Scaler();
	}

    void Update()
    {
        // 常にプレイヤーの階層を見ておく
        //nowLevel = GetPlayerPos.GetSetFloor;

        //// 階層が変わっていなければリターン
        //if (baseLevel == nowLevel) return;

        // 1フレーム前の階層情報と最新の階層情報が違っていたら
        //baseLevel = nowLevel;   // 階層を合わせて
        //Scaler();               // Scalerを実行

    }
	
    /// <summary>
    ///  自分のスケールを変更
    /// </summary>
    public void Scaler()
    {
        //if(nowLevel == baseLevel)
        //{
            gameObject.transform.localScale = Randmize();
            
        //}
    }

    /// <summary>
    ///  階層情報を受け取り、乱数を作りVector3型で返す
    /// </summary>
    /// <returns>スケール情報</returns>
    Vector3 Randmize()
    {
        nowLevel = (nowLevel + 1) * 10; // 0 + 1の十倍
        int scale = Random.Range(nowLevel - 9, nowLevel);   // 第0階層例：1～10
        Vector3 vecScale = new Vector3(scale, scale, scale);// スケールに反映
        return vecScale;
    }
}
