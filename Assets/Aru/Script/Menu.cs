using UnityEngine;
using System.Collections;


/*=================
    改善後スクリプト
 ================*/
public class Menu : MonoBehaviour
{
    public string[] SceneNameList;
    public GameObject fish;
    public Transform start, rankigun, credit, cFish;
    public Fade fade;
    public bool fadeFlg;

    void Start()
    {
        fadeFlg = false;
    }

    void Update()
    {
        if (fade.GetAlpha() == 0.0f && fadeFlg == false)
        {
            fade.gameObject.SetActive(false);
            fadeFlg = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Fish(Transform panel)
    {
        Fish(fish, panel, cFish);
    }

    public static void Fish(GameObject fish, Transform panel, Transform cFish)
    {
        Instantiate(fish, panel.position + cFish.TransformDirection(Vector3.back * 0.04f), Quaternion.identity);
    }

    public void GameStartButton()
    {
        Fish(start);

        fade.gameObject.SetActive(true);

        fade.Scene = SceneNameList[0];
        fade.FadeOut();
    }

    public void RankingButton()
    {
        Fish(rankigun);

        fade.gameObject.SetActive(true);

        fade.Scene = SceneNameList[1];
        fade.FadeOut();
    }

    public void CreditButton()
    {
        Fish(credit);

        fade.gameObject.SetActive(true);

        fade.Scene = SceneNameList[2];
        fade.FadeOut();
    }
}
