using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScr : MonoBehaviour
{
    public Fade fade;
    public GameObject fish;
    public Transform panel, cFish;
    private PlayerStatus playerState;
    public bool fadeFlg;


    void Start()
    {
        playerState = this.GetComponent<PlayerStatus>();
        fadeFlg = false;  
    }

    //↓0609バグ確認(Updateの処理通過しない)?
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PushButton_1();
        }

        if (fade.GetAlpha() == 0.0f && fadeFlg == false)
        {
            fade.gameObject.SetActive(false);
            fadeFlg = true;
        }
    }

    public void PushButton_1()
    {
        Menu.Fish(fish, panel, cFish);

        fade.gameObject.SetActive(true);
        fade.Scene = "Menu";
        fade.FadeOut();
    }

    public void PushButton_2()
    {
        Menu.Fish(fish, panel, cFish);

        fade.gameObject.SetActive(true);
        fade.Scene = "GamePlayScene";
        fade.FadeOut();
    }
}