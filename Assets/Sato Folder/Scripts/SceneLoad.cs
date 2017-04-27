using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Fade fade;

    void Start()
    {

    }

    void Update()
    {
    }

    public void SceneTitle()
    {
        fade.Scene = "TitleScene";
        fade.FadeOut();
    }

    public void SceneMenu()
    {
        fade.Scene = "Menu";
        fade.FadeOut();
    }

    public void SceneCredit()
    {
        fade.Scene = "Credit";
        fade.FadeOut();
    }

    public void SceneScore()
    {
        fade.Scene = "Score";
        fade.FadeOut();
    }

    public void SceneGamePlay()
    {
        fade.Scene = "GamePlayScene";
        fade.FadeOut();
    }

}
