using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ButtonsC : MonoBehaviour, IPointerEnterHandler {

    public MenuManager menuManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("On");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
