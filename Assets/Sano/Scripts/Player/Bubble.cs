using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

    public PlayerMove playerMove;
    ParticleSystem pSystem;

	// Use this for initialization
	void Start () {
        pSystem = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        float nowSpeed = playerMove.GetMoveSpeed();

        if (nowSpeed == 0) nowSpeed = 0.3f;
        else if (nowSpeed < 1) nowSpeed = 2;
        pSystem.Emit((int)nowSpeed*10);

    }
}
