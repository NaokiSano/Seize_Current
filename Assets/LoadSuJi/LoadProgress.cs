using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadProgress : MonoBehaviour
{
    public float offset;
    public Vector2 size;
    public Sprite[] spr;
    private Image[] imgs;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Init()
    {
        imgs = GetComponentsInChildren<Image>();

        float h = (imgs.Length - 1f) / 2f;

        for (int i = 0; i < imgs.Length; i++)
        {
            var rt = imgs[i].rectTransform;

            rt.sizeDelta = size;
            rt.anchoredPosition = Vector2.right * ((size.x + offset) * (i - h));
        }
    }

    public void SetPercentage(float progress)
    {
        int p = (int)(progress * 100f);

        for (int i = 0; i < imgs.Length; i++)
        {
            int pow = (int)Mathf.Pow(10f, imgs.Length - i - 1f);

            imgs[i].sprite = spr[p / pow];

            p %= pow;
        }
    }
}
