using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

/* =====================
 * プレイヤーの移動関係
 ==================== */

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed;     // 前進スピード
    public float RotateSpeed;   // 回転スピード
    public float BoostSpeed;    // ブースト率
    public float BoostDamageValue;          // ブースト時のダメージ数
    public CameraMotionBlur cameraBlur;     // モーションブラー

    private Animator anim;
    private PlayerStatus playerStatus;
    private Rigidbody rb;
    private Vector3 direction;  // 回転軸
    private bool moveEnable;    // 移動可能フラグ
    private Vector3 moveVel;    // 移動量

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        moveEnable = true;
        direction = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        playerStatus = GetComponent<PlayerStatus>();
        cameraBlur.enabled = false;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (cameraBlur) cameraBlur.enabled = false;

        if (moveEnable)
        {
            moveVel = Vector3.zero;
            Rotate();
            Boost();
        }
        else anim.speed = 0;
    }

    // 移動処理
    void Move()
    {
        /* ===========================================================================================
         * TransformDirectionでカメラに対し、(Vector3.forward)でZ軸方向へ移動 * Vertical * スピード
         * Math.Max()で、大きい方を返す ※この場合、0とVertical。つまり0と-1or1を比較する
         * 上で計算された変数velを、rb.velocityにそのまま代入すると魚が移動する
         * ===========================================================================================*/
         if(Input.GetKey(KeyCode.W))
        {
            moveVel = transform.TransformDirection(Vector3.forward * Mathf.Max(0, Input.GetAxis("Vertical")) * MoveSpeed);
            rb.velocity = new Vector3(moveVel.x, moveVel.y, moveVel.z); 
        }
    }

    // 回転処理
    void Rotate()
    {
        /* ===========================================================================================
         * Vector3型に、縦軸横軸の値をぶっこむ * スピード  ※ 0の代入は、その軸の回転をしないため
         * 上の変数をMoveRotationに使うと、そのXYZの中間値でスムーズに移動する
         * ===========================================================================================*/
        direction += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f) * RotateSpeed;

        // 回転度の制限(反対向きにならないようにするため)
        if (direction.x < -90)
        {
            direction.x = -90;
        }
        if (direction.x > 90)
        {
            direction.x = 90;
        }

        rb.MoveRotation(Quaternion.Euler(direction));
    }

    // ブースト
    void Boost()
    {
        /* ====================================
         * Jumpボタンを押したら、元の移動スピードを保存
         * 移動スピードにブースト率をかけて、移動させる
         * Playerの腹減り度をDamageValue分を追加で減らし、
         * 移動スピードを元のスピードに戻す
         * ==================================*/
        if(Input.GetAxis("Jump") == 1)
        { 
            float oldSpeed = MoveSpeed;
            MoveSpeed *= BoostSpeed;
            anim.speed = MoveSpeed-9;
            Move();
            cameraBlur.enabled = true;
            playerStatus.DamageHangry(BoostDamageValue);          
            MoveSpeed = oldSpeed;
        }
        else
        {
            anim.speed = MoveSpeed-8;
            Move();
        }
    }

    /// <summary>
    ///  プレイヤーの移動可能判断フラグ
    /// </summary>
    /// <param name="flag"></param>
    public void ChangeMoveEnable(bool flag)
    {
        moveEnable = flag;
    }

    /// <summary>
    ///  マウスX軸の回転量取得
    /// </summary>
    /// <returns></returns>
    public float GetMousePosition()
    {
        return direction.x;
    }

    /// <summary>
    ///  Player移動スピードの取得
    /// </summary>
    /// <returns>移動スピード</returns>
    public float GetMoveSpeed()
    {
        float result = Mathf.Max(moveVel.x, moveVel.y, moveVel.z);
        result = Mathf.Abs(result);
        return result;
    }
}
