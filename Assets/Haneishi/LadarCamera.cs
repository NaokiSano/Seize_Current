using UnityEngine;
using System.Collections;

public class LadarCamera : MonoBehaviour
{
    public float rectSize, far;
    private Camera cam;
    public Transform player;
    public LadarCanvas canvas;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
        cam.farClipPlane = far * player.localScale.x;

        Vector3 dir = Camera.main.transform.TransformDirection(Vector3.forward);

        dir.y = 0f;

        transform.LookAt(transform.position + Vector3.down, dir);
        transform.position = player.position + Vector3.up * (far / 2f);
    }
}
