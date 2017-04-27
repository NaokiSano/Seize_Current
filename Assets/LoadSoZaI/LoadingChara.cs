using UnityEngine;
using System.Collections;

public class LoadingChara : MonoBehaviour
{
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.TransformDirection(Vector3.forward * (100f * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.TransformDirection(Vector3.forward * (100f * Time.deltaTime)));
    }

    void LateUpdate()
    {
        Transform cam = Camera.main.transform;

        cam.rotation = transform.rotation * Quaternion.Euler(new Vector3(45f, 180f, 0f));
        cam.position = transform.position + cam.TransformDirection(Vector3.back * 0.6f);
    }
}
