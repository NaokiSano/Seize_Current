using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreRanking : MonoBehaviour {

    public SaveScript saveScript;
    public Text text;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        text.text = saveScript.StringRanking();
	}
}
