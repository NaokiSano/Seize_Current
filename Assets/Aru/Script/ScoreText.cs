using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class ScoreText : MonoBehaviour {

    public GameObject Text;
    private SaveScript saveScript;
    private PlayerStatus playerState;
  
	// Use this for initialization
	void Start () {
        saveScript = this.GetComponent<SaveScript>();
        playerState = this.GetComponent<PlayerStatus>();
        //gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
}
