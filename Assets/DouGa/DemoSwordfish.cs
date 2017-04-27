using UnityEngine;
using System.Collections;

public class DemoSwordfish : MonoBehaviour
{
    private bool mdiEsc = false;
    private Rigidbody rb;
    public Transform player;
    public DemoManager dm;
    public DemoShark sameAsset;
    private DemoShark same;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (!rb.isKinematic)
        {
            rb.MoveRotation(Quaternion.LookRotation(player.position - rb.position));
            rb.AddForce(transform.TransformDirection(Vector3.forward * (150f * Time.deltaTime)));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerCol1")
        {
            mdiEsc = true;

            other.GetComponentInParent<AudioSource>().Play();
            other.GetComponentInParent<Rigidbody>().AddTorque(Vector3.up * 160f);

            GOIS();
        }

        if (other.name == "PlayerCol2")
        {
            Quaternion r = Quaternion.Euler(new Vector3(60f, -90f, 0f));
            Vector3 p = transform.position + r * Vector3.back * 1.5f;

            same = (DemoShark)Instantiate(sameAsset, p, r);

            same.kajiki = transform;

            GOIS();
        }

        if (other.tag == "DemoSame")
        {
            rb.isKinematic = true;

            transform.parent = other.transform;

            same.EatKajiki();

            StartCoroutine(dm.SameEating());

            GOIS();
        }
    }

    void GOIS()
    {
        if (Input.GetKey(KeyCode.X))
            throw new System.Exception();
    }

    public bool MadaiEscape
    {
        get
        {
            return mdiEsc;
        }
    }
}
