using UnityEngine;
using System.Collections;

public class GameQuit : MonoBehaviour {

    public GameObject[] GameQuitButtons;
    public GameObject GoEscText;
    bool isEsc;     // Escが押されたか

    // Use this for initialization
    void Start () {
        for (int i = 0; i < GameQuitButtons.Length; i++)
        {   // ボタン類をオフに
            GameQuitButtons[i].SetActive(false);
        }
        isEsc = false;
    }
	
	// Update is called once per frame
	void Update () {
        //EscapeKey();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    public void EscapeKey()
    {
        if (Input.GetKey(KeyCode.Escape) && !isEsc)
        {
            isEsc = true;
            Cursor.visible = true;
            Time.timeScale = 0.1f;
            GoEscText.SetActive(false);

            for(int i=0;i < GameQuitButtons.Length; i++)
            {
                GameQuitButtons[i].SetActive(true);
            }
        }
    }

    public void RebornEscape()
    {
        isEsc = false;
        Cursor.visible = false;
        Time.timeScale = 1;
        GoEscText.SetActive(true);

        for (int i = 0; i < GameQuitButtons.Length; i++)
        {
            GameQuitButtons[i].SetActive(false);
        }
    }

    public void GameQuits()
    {
        Application.Quit();
    }
}
