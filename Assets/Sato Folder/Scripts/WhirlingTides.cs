using UnityEngine;
using System.Collections;

public class WhirlingTides : MonoBehaviour {

    //今のところ海流と強さが違うだけ
    //渦潮の向き、強さ
    public float powerX, powerY, powerZ;

    public float inertia;

    void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerStay(Collider col)
    {
        
        //サイズ比較
        if (col.gameObject.transform.localScale.x > transform.localScale.x)
        {
            return;
        }
        else if (col.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySE("uzu");
            col.transform.parent.GetComponent<Rigidbody>().AddForce(6 * Vector3.up, ForceMode.Impulse);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            col.transform.GetComponent<Rigidbody>().AddForce(6 * Vector3.forward, ForceMode.Impulse);
        }
    }

    void OnTriggerExit(Collider col)
    {
        AudioManager.Instance.StopSE();
    }
}
