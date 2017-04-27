using UnityEngine;
using System.Collections;

public class Kaisou3 : KaisouAbs {


	// Use this for initialization

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

        // 2だった時、触れたら3になる
        if (manageScript.GetSetNowLevel == 2)
        {
            //enem.SetLevel(3);
            manageScript.GetSetNowLevel = 3;
        }
        // 3だったら2になる
        else
        {
            //enem.SetLevel(2);
            manageScript.GetSetNowLevel = 2;
        }

    }
}
