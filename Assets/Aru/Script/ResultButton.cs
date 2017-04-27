using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PushButton()
    {
        SceneManager.LoadScene("Result", LoadSceneMode.Additive);
    }
}
