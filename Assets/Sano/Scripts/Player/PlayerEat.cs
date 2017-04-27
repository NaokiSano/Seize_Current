using UnityEngine;
using EnemyStateMachine;
using System.Collections;
using System.Collections.Generic;

public class PlayerEat : MonoBehaviour {
    
    /* ======================
     *  プレイヤーが敵を捕食
     ===================== */

    public SmoothFollow smoothFollow;
    public int UpScaleDivision; // 巨大化数値の割る数
    public GameObject chara;
    private List<Transform> EnemyList = new List<Transform>();

    EnemyEatMark enemMark;
    PlayerStatus playerStatus;
    Transform enemyPos;
    bool cameraDisUp, canEat, eatClick;
    float upScale, enemyScale;

	// Use this for initialization
	void Start () {
        playerStatus = this.GetComponent<PlayerStatus>();
        cameraDisUp = false;
        canEat = false;
        eatClick = false;
	}

    void Update()
    {
        if(eatClick && enemyPos!=null)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyPos.position, 0.1f);
        }
        serchTag();
    }

    void OnTriggerStay(Collider other)
    {
        // 範囲内に入ったものが、敵以外なら処理から抜ける
        if (other.gameObject.tag != "Enemy")
            return;

        /* 敵ならば、プレイヤーの大きさと
           その敵の大きさを比較する */
        // 自分のほうが大きければ、捕食可能
        if (other.transform.lossyScale.x < this.transform.lossyScale.x)
        {
            //Debug.Log("捕食可能");
            canEat = true;

            enemyScale = other.transform.lossyScale.x;
            upScale = other.transform.localScale.x / UpScaleDivision; // 敵のスケールを割る
            enemyPos = other.transform;
            //if (Input.GetMouseButton(0))
            //{
            //    AudioManager.Instance.PlaySE("eat");
            //    eatClick = true;
            //    enemMark = other.GetComponent<EnemyEatMark>();
            //    if(enemMark != null) enemMark.EnableMark();
            //}

            //リストにタグEnemyと捕食可能Enemyを追加
            EnemyList.Add(other.transform);

        }
        else // プレイヤーのほうが小さかったら
        {
            enemMark = other.GetComponent<EnemyEatMark>();
            if(enemMark != null)enemMark.EnableDangerMark();
            canEat = false;
            //Debug.Log("捕食不可能");
        }
    }

    public void ChildOnCollisionEnter(Collider col)
    {
                //Debug.Log(canEat);
        if (col.gameObject.tag == "Enemy" && canEat)
        {
            this.gameObject.transform.localScale +=
                new Vector3(upScale, upScale, upScale);   // その割ったスケールをプレイヤーに足す
            playerStatus.RecoveryHangry(enemyScale);    // 腹減り度の回復
            smoothFollow.ChangeDistance(upScale / 1.5f);
            eatClick = false;
            canEat = false;

            enemMark = null;
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Enemy" && !canEat)
        {   // 敵のほうが大きかったら死亡
            //chara.SetActive(false);
            playerStatus.DeadType(true);
            playerStatus.DamageHangry(150);
        }
    }

    //リスト初期化
    private void FixedUpdate()
    {
        EnemyList.Clear();
    }
    //計算処理
    private void serchTag()
    {
        EnemyList.RemoveAll(a => !a);

        if (EnemyList.Count == 0)
            return;

        float d = Vector3.SqrMagnitude(transform.position - EnemyList[0].position);
        Transform e = EnemyList[0];

        for (int i = 1; i < EnemyList.Count; i++)
        {
            float _d = Vector3.SqrMagnitude(transform.position - EnemyList[i].position);

            if (_d < d)
            {
                d = _d;
                e = EnemyList[i];
            }
        }

        if (Input.GetMouseButton(0))
        {
            AudioManager.Instance.PlaySE("eat");
            eatClick = true;
            enemMark = e.GetComponent<EnemyEatMark>();
            if (enemMark != null) enemMark.EnableMark();

        }
    }
}
