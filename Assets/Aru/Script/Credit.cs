using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Credit : MonoBehaviour
{
    public GameObject fish;
    public Transform panel, cFish;
    public Fade fade;
    public bool fadeFlg;

    void Start()
    {
        fadeFlg = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ButtonPush();
        }

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

    public void ButtonPush()
    {
        Menu.Fish(fish, panel, cFish);

        fade.gameObject.SetActive(true);

        fade.Scene = "Menu";
        fade.FadeOut();
    }
}