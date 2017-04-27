using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemain : MonoBehaviour 
{
    public Fade fade;
	
	void Start () {
	}

    void Update()
    {
       
    }

    void OnGUI()
    {
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
    
        if (GUI.Button(new Rect(327, 290, 200, 54), "リザルトへ", buttonStyle))
        {
            fade.Scene = "Result";
            fade.FadeOut();   
        }
    }
    //こっちの方にエンディング突っ込むのかは知らん

}
