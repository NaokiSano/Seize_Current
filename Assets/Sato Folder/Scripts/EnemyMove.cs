using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    //移動速度
    public float speed = 3f;
    //回転速度
    public float rotationSmooth = 3f;
    //目標地点
    private Vector3 targetPosition;

    private Vector3 startPosition;

    private float changeTargetSqrDistance = 5f;

	void Start ()
    {
        startPosition = transform.position;
        targetPosition = GetRandomPositionOnLevel();
	}
	
	void Update ()
    {
        // 目標地点との距離が小さければ、次のランダムな目標地点を設定する
        float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
        if (sqrDistanceToTarget < changeTargetSqrDistance)
        {
            targetPosition = GetRandomPositionOnLevel();
        }

        //目標地点の方向を向く
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

        //前方に進む
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    //目標地点を決める
    public Vector3 GetRandomPositionOnLevel()
    {
        //移動範囲
        float levelSize = 20f;
        Vector3 vecSize = new Vector3(Random.Range(-levelSize, levelSize), Random.Range(-levelSize, levelSize), Random.Range(-levelSize, levelSize));
        Vector3 levelVecSize = new Vector3(vecSize.x + startPosition.x, vecSize.y + startPosition.y, vecSize.z + startPosition.z);
        return levelVecSize;
    }
}
