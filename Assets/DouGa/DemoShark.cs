using UnityEngine;
using System.Collections;

public class DemoShark : MonoBehaviour
{
    private bool isEating = false;
    public AudioSource eat, fadeOut;
    private Rigidbody rb;
    public Transform kajiki;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.TransformDirection(Vector3.forward * 5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (!isEating)
            rb.MoveRotation(Quaternion.LookRotation(kajiki.transform.position - rb.position));

        rb.AddForce(transform.TransformDirection(Vector3.forward * (250f * Time.deltaTime)));
    }

    public void EatKajiki()
    {
        isEating = true;

        fadeOut.Play();
    }

    public bool IsEating
    {
        get
        {
            return isEating;
        }
    }
}
