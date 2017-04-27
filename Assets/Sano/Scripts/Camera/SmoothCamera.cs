using UnityEngine;
using System.Collections;

/*===== 作りかけ　ボツ =====*/

public class SmoothCamera : MonoBehaviour {

    public Transform FollowTarget;  // 追従ターゲット
    public float Distance;          // ターゲットとの遠さ(距離)
    public float Height;            // ターゲットとの高さ(どれくらい見下ろすか)
    public float Angle;             // カメラアングル(見下ろす角度)

    /* カメラ移動速度(一応) */
    public float DistanceSpeed;         // 距離のスピード
    public float HeightSpeed;           // 上下高さ回転のスピード
    public float RotationSmoothSpeed;   // 左右横回転をなめらかにする為のスピード
    public float RotationSpeed;         // 左右横回転の基本スピード

    /* カメラの左右回転 */
    public bool AngleChangeEnable;      // カメラの回転を有効にするか
    private KeyCode rotationLeftKey;    // カメラ左回転 
    private KeyCode rorationRightKey;   // カメラ右回転
    private float angle;                // カメラ横回転の相対値

    /* カメラの高さ操作 */



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
