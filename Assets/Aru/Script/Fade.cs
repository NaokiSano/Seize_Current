using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fade : MonoBehaviour
{
    public enum FadeState
    {
        None, In, Out
    }

    private float a = 1.0f;
    private FadeState fade = FadeState.In;
    public Color color;
    private RawImage img;
    public string Scene;
   

    // Use this for initialization
    void Start()
    {
       
        img = GetComponent<RawImage>();

    }

    // Update is called once per frame

    void Update()
    {

        if (fade == FadeState.In)
        {
            a -= Time.deltaTime;

            if (a <= 0f)
            {
                a = 0f;
                fade = FadeState.None;                
            }

            color.a = a;
            img.color = color;
        }
        else if (fade == FadeState.Out)
        {
            a += Time.deltaTime;

            if (a >= 1f)
            {
                a = 1f;
                //シーン移行
                SceneManager.LoadScene(Scene);
            }

            color.a = a;
            img.color = color;
        }

    }

    public void FadeOut()
    {
        if (fade == FadeState.None)
            fade = FadeState.Out;
    }

    public float GetAlpha()
    {
        return a;
    }
}
