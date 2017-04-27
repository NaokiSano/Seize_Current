using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetMethod : MonoBehaviour {

    public GameObject[] Kaisou;
    private int Nowhierarchy;   //現在の階層


    // Use this for initialization
    void Start () {
        Nowhierarchy = 0;      
    }

    /// <summary>
    /// 階層の初期化 
    /// </summary>
    public void InitializeNowFloor()
    {
        Nowhierarchy = 0;
    }

    /// <summary>
    ///  プレイヤーの階層を設定、取得
    /// </summary>
    public int GetSetFloor
    {
        set { Nowhierarchy = value; }
        get { return Nowhierarchy; }
    }
}
