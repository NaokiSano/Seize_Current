using UnityEngine;
using System.Collections;

public class LadarPointStarter : MonoBehaviour
{
    public Color color;
    public GameObject point;

    // Use this for initialization
    void Start()
    {
        var m = (GameObject)Instantiate(point, transform.position, Quaternion.Euler(Vector3.right * 90f));

        m.GetComponent<SpriteRenderer>().color = color;
        m.GetComponent<LadarPoint>().obj = transform;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
