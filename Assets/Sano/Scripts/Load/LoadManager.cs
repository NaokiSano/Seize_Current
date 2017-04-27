using UnityEngine;
using System.Collections;

public class LoadManager : MonoBehaviour {

    public LoadingImage loadimage;
    public LoadText loadingtext;
    public GameObject ClickStartText;
    bool isLoading;


	// Use this for initialization
	void Start () {
        ClickStartText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if(loadingtext.GetIsLoading())
        {
            loadimage.SetIsLoad(false);
            ClickStartText.SetActive(true);
        }
	}
}
