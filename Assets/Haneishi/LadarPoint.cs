using UnityEngine;
using System.Collections;

public class LadarPoint : MonoBehaviour
{
    public Transform obj;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!obj)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = obj.position;
    }
}
