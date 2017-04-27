using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingImage : MonoBehaviour {

    private Image image;
    bool isLoading;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        isLoading = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isLoading)
        {
            transform.Rotate(new Vector3(0, 0, -5));
            Images();
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 5));
            image.fillAmount = 1;
        }
	}

    void Images()
    {
        image.fillAmount += 0.8f * Time.deltaTime;
        if (image.fillAmount >= 1) image.fillAmount = 0;

        transform.Rotate(new Vector3(0, 0, 2));
    }

    public void SetIsLoad(bool flag)
    {
        isLoading = flag;
    }
}
