using UnityEngine;
using System.Collections;

public class Kaisou2 : KaisouAbs {


    protected override void Start()
    {
        
    }

    protected override void OnTriggerEnter(Collider other)
    {
        // プレイヤー以外
        if (other.gameObject.tag != ("Player"))
        {
            return;
        }

        // 1の時、触れたら2になる
        if (manageScript.GetSetNowLevel == 1)
        {
            //enem.SetLevel(2);
            manageScript.GetSetNowLevel = 2;
        }
        // 2の時、1になる
        else
        {
            //enem.SetLevel(1);
            manageScript.GetSetNowLevel = 1;
        }

    }
}
