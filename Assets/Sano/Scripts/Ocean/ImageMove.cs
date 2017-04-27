using UnityEngine;
using System.Collections;

public class ImageMove : MonoBehaviour
{

    public Transform player;
    public float mikire;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //// Image移動
        //float move = -Camera.main.transform.position.y;
        //GetComponent<RectTransform>().localPosition = Vector3.up * (Mathf.Clamp(move * 100 - 50, -800, 800));
        // Image移動
        float move = -player.position.y;
        GetComponent<RectTransform>().localPosition = Vector3.up * (Mathf.Clamp(move * 1, -mikire, mikire));

    }
}