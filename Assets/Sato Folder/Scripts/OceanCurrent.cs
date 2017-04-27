using UnityEngine;
using System.Collections;

public class OceanCurrent : MonoBehaviour {

    //海流の向き、強さ
    public float Speed = 0.04f;
	private float scaleMin;
    private GameObject _child;
    private bool playerMoveFlg;

    //慣性用
    public float inertia;

    void Start ()
    {
        playerMoveFlg = false;
        _child = transform.FindChild("Exit").gameObject;
        //Debug.Log(_child.gameObject.transform.position);
		if (transform.localScale.x > transform.localScale.y) 
		{
			scaleMin = transform.localScale.y;
		} 
		else if (transform.localScale.x > transform.localScale.z) 
		{
			scaleMin = transform.localScale.z;
		}
		else
			scaleMin = transform.localScale.x;
	}

	void Update ()
    {
	   
	}

    void OnTriggerStay(Collider col)
    {
        
        //サイズ比較
        if (col.gameObject.transform.localScale.x > scaleMin)
        {
            return;
        }
        else if(col.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySE("rever");
            col.transform.parent.GetComponent<Rigidbody>().AddForce(4 * Vector3.forward, ForceMode.Impulse);
        }
        else if(col.gameObject.tag == "Enemy")
        {
            col.transform.GetComponent<Rigidbody>().AddForce(4 * Vector3.forward, ForceMode.Impulse);
        }
    }

    void OnTriggerExit(Collider col)
    {
        AudioManager.Instance.StopSE();
    }
}