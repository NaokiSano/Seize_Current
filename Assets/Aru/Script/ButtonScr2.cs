using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScr2 : MonoBehaviour {

    public Fade fade;
    public PlayerStatus playerState;
    public GameObject MainCamera;
    //private bool ButtonChangeFlag2;
    //private MyCanvas myCanvas;
    

    void Start()
    {
        //MainCamera.SetActive(false);
        //gameObject.SetActive(false);
        playerState = this.GetComponent<PlayerStatus>();
        //myCanvas = this.GetComponent<MyCanvas>();
    }
	// Use this for initialization
	
	// Update is called once per frame
    //↓0609バグ確認(Updateの処理通過しない)?
    void Update() { 
        
    }

    public void PushButton_2()
    {
        fade.Scene = "GamePlayScene";
        fade.FadeOut();
    }
}
