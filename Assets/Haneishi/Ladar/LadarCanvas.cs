using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LadarCanvas : MonoBehaviour
{
    public float lineRotSpd;
    private float lineRot = 0f;
    public AudioSource oto;
    private Color tenMetsuColor;
    public Image lineImg, tenMetsuImg;

    // Use this for initialization
    void Start()
    {
        tenMetsuColor = Color.white;
        tenMetsuColor.a = 0f;

        lineImg.rectTransform.sizeDelta = new Vector2(1f, ((RectTransform)transform.parent).sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
        Line();
        TenMetsu();
    }

    void Line()
    {
        lineRot += lineRotSpd * Time.deltaTime;

        if (lineRot >= 360f)
        {
            lineRot -= 360f;

            tenMetsuColor.a = 1f;

            oto.Play();
        }

        lineImg.transform.localEulerAngles = Vector3.back * lineRot;
    }

    void TenMetsu()
    {
        if (tenMetsuColor.a == 0f)
            return;

        tenMetsuImg.color = tenMetsuColor;

        if (tenMetsuColor.a <= 0f)
        {
            tenMetsuColor.a = 0f;
            return;
        }

        tenMetsuColor.a -= 1f * Time.deltaTime;
    }
}
