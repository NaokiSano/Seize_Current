using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

    //フラグ返すだけ

    //Playerが近くにいるか？
    private bool HitFlg;

	void Start ()
    {
        HitFlg = false;
	}
	
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag != "Player")
        {
            return;
        }
        HitFlg = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag != "Player")
        {
            return;
        }
        HitFlg = false;
    }

    public bool isHitFlg()
    {
        return HitFlg;
    }

}
