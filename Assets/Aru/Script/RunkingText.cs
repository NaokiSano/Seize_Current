using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RunkingText : MonoBehaviour {

    //public GameObject Text;
    private SaveScript saveScript;
    private ScoreText scoreText;
    private PlayerStatus playerState;

	// Use this for initialization
	void Start ()
    {
        playerState = this.GetComponent<PlayerStatus>();
        saveScript = this.GetComponent<SaveScript>();
        scoreText = this.GetComponent<ScoreText>();
        //gameObject.SetActive(false);
	}
	

	// Update is called once per frame
	void Update () 
    {
        //if (playerState.GetDeadFlag() == true)
        //{
        //    MyCanvas.SetActive("RunkingText", true);
        //}
	}

   //void Runnkinng()
   // {  
    
   // }
}
