using UnityEngine;
using System.Collections;

public abstract class KaisouAbs : MonoBehaviour {

    //public GameObject GameManager;
    public GameManager manageScript;

    protected abstract void Start();

    protected abstract void OnTriggerEnter(Collider other);
}
