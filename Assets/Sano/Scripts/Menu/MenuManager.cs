using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public Transform Fish;
    public Transform[] Pos;
    public Button[] Buttons;
    public Menu menuScript;
    int now;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Fish.position = Pos[0].position;
        now = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (now <= 0)
            {
                now = 0;
                return;
            }
            now--;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(now >= 2)
            {
                now = 2;
                return;
            }
            now++;
        }

        Fish.position = Pos[now].position;

        EnableButton();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // ボタン決定したら
    void EnableButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (now == 0) menuScript.GameStartButton();
            else if (now == 1) menuScript.RankingButton();
            else menuScript.CreditButton();
        }
    }

    public void SetFishPos(Vector3 pos)
    {
        Fish.position = pos;
    }

}
