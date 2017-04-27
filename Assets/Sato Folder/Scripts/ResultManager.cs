using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{

    public SaveScript saveScript;
    public Text scoreText;
    public Text rankingText;

    private int score;
    private bool drawFlg;

    void Start()
    {
        //Textを非表示
        scoreText.gameObject.SetActive(false);
        rankingText.gameObject.SetActive(false);
        saveScript.Start();

        drawFlg = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (drawFlg == false)
        {

            scoreText.gameObject.SetActive(true);
            score = PlayerStatus.GetScale() * 100;
            scoreText.text = "Score:             " + score.ToString() + "point";
            rankingText.gameObject.SetActive(true);
            saveScript.Save(score);

            //saveScript.deleteRanking(); //ランキング初期化
            rankingText.text = saveScript.StringRanking();

            drawFlg = true;
        }
    }
}
