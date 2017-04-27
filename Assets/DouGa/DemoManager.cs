using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DemoManager : MonoBehaviour
{
    private float camRot = 0f;
    public string nextScene;
    public Transform player;
    private Transform cam;
    public DemoSwordfish kajiki;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        camRot += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(nextScene);
    }

    void FixedUpdate()
    {
        player.GetComponent<Rigidbody>().AddForce(player.TransformDirection(Vector3.forward * (125f * Time.deltaTime)));
    }

    void LateUpdate()
    {
        float t = 1f, ry = Mathf.SmoothStep(0f, 180f, Mathf.Clamp((camRot - t) / (3f - t), 0f, 1f));
        Quaternion r = player.rotation * Quaternion.Euler(new Vector3(15f, ry, 0f));

        if (kajiki.MadaiEscape)
            cam.LookAt(kajiki.transform);
        else
            cam.rotation = r;

        cam.position = player.position + r * Vector3.back * Mathf.SmoothStep(10f, 0.5f, Mathf.Min(camRot / 2f, 1f));
    }

    public IEnumerator SameEating()
    {
        yield return new WaitForSeconds(2f);

        cam.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(nextScene);
    }
}
