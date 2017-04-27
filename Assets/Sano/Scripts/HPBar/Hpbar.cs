using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hpbar : MonoBehaviour {

    Image hpBarImage;
    RectTransform rect;
    int barHeight = 30;

    //public RectTransform rect;

	// Use this for initialization
	void Start () {
        hpBarImage = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
	}

    public void Update()
    {

    }

    public void ChangeBar(float value)
    {   // HPバーのサイズに、value値をそのまま入れる(※３は倍率)
        //hpBarImage.rectTransform.sizeDelta = new Vector2(value * 3, barHeight);
        //rect.sizeDelta = Vector2.right * value;
        float hangry = value / 150;
        rect.sizeDelta = new Vector2(500 * hangry, 100);
    }
}
