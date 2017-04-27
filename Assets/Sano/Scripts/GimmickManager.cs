using UnityEngine;
using System.Collections;

public class GimmickManager : MonoBehaviour {

    public Transform[] spawnPos;    // スポーン場所
    public GameManager player;        // プレイヤー
    public GameObject[] gimmcks;    // ギミック
    int nowFloor, oldFloor, gimmickNum; // 今のフロア、前のフロア、ギミックナンバー

	// Use this for initialization
	void Start () {
        oldFloor = 10;
        nowFloor = 0;
	}
	
	// Update is called once per frame
	void Update () {
        nowFloor = player.GetSetNowLevel;   // フロアを取得

        if (nowFloor == oldFloor) return;   // 現フロアと前フロアが同じならリターン

        // spawnPosの子要素を最大値とする
        for(int i=0; i<spawnPos[nowFloor].childCount; i++)
        {   // ギミックを選出
            gimmickNum = Random.Range(0, gimmcks.Length);
            
            // ゼロ番目（海流）
            if(gimmickNum == 0)
            {
                float rotateNumX = Random.Range(-100, 100) / 10;
                float rotateNumZ = Random.Range(-100, 100) / 10;
                Instantiate(gimmcks[gimmickNum], spawnPos[nowFloor].GetChild(i).position, spawnPos[nowFloor].GetChild(i).rotation = new Quaternion(rotateNumX,0, rotateNumZ,0));
            }
            else // (渦)
            {
                Instantiate(gimmcks[gimmickNum], spawnPos[nowFloor].GetChild(i).position, spawnPos[nowFloor].GetChild(i).rotation);
            }         
        }
        oldFloor = nowFloor;     
	}
}
