using UnityEngine;
using System.Collections;

public class EatSpehere : MonoBehaviour {

    PlayerEat sendCollider;

	// Use this for initialization
	void Start () {
        // ヒット情報を送る親オブジェクトを設定
        GameObject playerEat = gameObject.transform.parent.gameObject;
        sendCollider = playerEat.GetComponent<PlayerEat>();
    }
	
    void OnTriggerEnter(Collider enemey)
    {   // 食べることができるなら、ヒット時にDestroyを
        // 親でGameObjectでやる。ここではヒットを返すだけ
        sendCollider.ChildOnCollisionEnter(enemey);
    }
}
