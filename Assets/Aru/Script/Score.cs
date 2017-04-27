using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Fade fade;

    public void ButtonPush()
    {
        fade.Scene = "Menu";
        fade.FadeOut();
    }
}