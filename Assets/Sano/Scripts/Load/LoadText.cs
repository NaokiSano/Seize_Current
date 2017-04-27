using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadText : MonoBehaviour {

    public LoadProgress loadProgress;
    Text loadT;
    AsyncOperation async;
    bool isLoad;

    IEnumerator Start()
    {

        loadT = GetComponent<Text>();
        async = SceneManager.LoadSceneAsync("GamePlayScene");
        async.allowSceneActivation = false;
        loadProgress.Init();
        while (async.progress < 0.9f)
        {
            isLoad = false;
            loadProgress.SetPercentage(async.progress);
            //loadT.text = (int)async.progress * 100 + " ％";
            yield return new WaitForEndOfFrame();
        }

        isLoad = true;
        loadProgress.SetPercentage(1);
        //loadT.text = "100%";

        yield return async;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && isLoad)
        {
            async.allowSceneActivation = true;
        }
    }

    public bool GetIsLoading()
    {
        return isLoad;
    }
}
