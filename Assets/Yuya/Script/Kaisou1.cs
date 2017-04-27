using UnityEngine;
using System.Collections;
using System;

public class Kaisou1 : KaisouAbs {


    protected override void Start()
    {
        //manageScript = GameManager.GetComponent<GameManager>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        // プレイヤー以外
        if (other.gameObject.tag != ("Player"))
        {
            return;
        }

        // 0の時、触れたら1になる
        if (manageScript.GetSetNowLevel == 0)
        {
            //enem.SetLevel(1);
            manageScript.GetSetNowLevel = 1;
        }
        // 1の時、0になる
        else
        {
            //enem.SetLevel(0);
            manageScript.GetSetNowLevel = 0;
        }
    }


}
