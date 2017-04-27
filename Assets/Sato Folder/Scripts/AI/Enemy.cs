using UnityEngine;
using System.Collections;

namespace EnemyStateMachine
{

    public enum EnemyState
    {
        Wander, //徘徊
        Pursuit,//追跡
        Gateway,//逃走
    }

    public class Enemy : StatefulObjectBase<Enemy, EnemyState>
    {

        private Transform player;

        //移動速度
        private float speed;
        //回転速度
        private float rotationSmooth;
        //目標地点
        private Vector3 targetPosition;

        private Vector3 startPosition;

        private bool isPlayerFlg;

        private bool eatFlg;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            speed = gameObject.transform.lossyScale.x / 2000 + 0.02f;
            rotationSmooth = 8f;
            targetPosition = Vector3.zero;
            isPlayerFlg = false;
            eatFlg = false;

            startPosition = transform.position;

            player = GameObject.FindWithTag("Player").transform;

            // ステートマシンの初期設定
            stateList.Add(new StateWander(this));
            stateList.Add(new StatePursuit(this));
            stateList.Add(new StateGateWay(this));

            stateMachine = new StateMachine<Enemy>();

            ChangeState(EnemyState.Wander);
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag != "Player")
            {
                return;
            }

            isPlayerFlg = true;

        }

        void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag != "Player")
            {
                return;
            }

            isPlayerFlg = false;
        }

        public bool GetSetCanEat
        {
            set { eatFlg = value; }
            get { return eatFlg; }
        } 

        /// <summary>
        /// ステート：徘徊
        /// </summary>
        private class StateWander : State<Enemy>
        {

            private float changeTargetSqrDistance = 5f;

            public StateWander(Enemy owner) : base(owner) { }

            public override void Enter()
            {
                owner.targetPosition = GetRandomPositionOnLevel();
            }

            public override void Excute()
            {

                if(owner.isPlayerFlg)
                {
                    //Debug.Log("player" + owner.player.lossyScale.x + "enemy" + owner.transform.lossyScale.x);
                    //サイズ比較
                    if(owner.transform.lossyScale.x > owner.player.lossyScale.x)
                    {
                        owner.ChangeState(EnemyState.Pursuit);
                    }
                    else if(owner.transform.lossyScale.x < owner.player.lossyScale.x)
                    {
                        owner.ChangeState(EnemyState.Gateway);
                    }
                }

                // 目標地点との距離が小さければ、次のランダムな目標地点を設定する
                float sqrDistanceToTarget = Vector3.SqrMagnitude(owner.transform.position - owner.targetPosition);
                if (sqrDistanceToTarget < changeTargetSqrDistance)
                {
                    owner.targetPosition = GetRandomPositionOnLevel();
                }

                //目標地点の方向を向く
                //Quaternion targetRotation = Quaternion.LookRotation(owner.targetPosition - owner.transform.position);
                //owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime * owner.rotationSmooth);

                var targetRotation = Quaternion.LookRotation(owner.targetPosition - owner.transform.position).eulerAngles;
                owner.transform.localRotation = Quaternion.Slerp(owner.transform.localRotation,Quaternion.Euler(targetRotation) , Time.deltaTime * owner.rotationSmooth);

                //前方に進む
                //owner.transform.Translate(Vector3.forward * owner.speed * Time.deltaTime);

                //目標に向かって進む
                owner.transform.position = Vector3.MoveTowards(owner.transform.position, owner.targetPosition, owner.speed);
            }

            public override void Exit(){ }

            //目標地点を決める
            public Vector3 GetRandomPositionOnLevel()
            {
                //移動範囲
                float levelSize = 10f;
                Vector3 vecSize = new Vector3(Random.Range(-levelSize, levelSize), Random.Range(-levelSize, levelSize), Random.Range(-levelSize, levelSize));
                Vector3 levelVecSize = new Vector3(vecSize.x + owner.startPosition.x, vecSize.y + owner.startPosition.y, vecSize.z + owner.startPosition.z);
                return levelVecSize;
            }
        }

        /// <summary>
        /// ステート：追跡
        /// </summary>
        private class StatePursuit : State<Enemy>
        {
            public StatePursuit(Enemy owner) : base(owner) { }

            public override void Enter() { }

            public override void Excute()
            {
                if(owner.isPlayerFlg == false)
                {
                    owner.ChangeState(EnemyState.Wander);
                }
                else if(owner.transform.localScale.x < owner.player.localScale.x)
                {
                    owner.ChangeState(EnemyState.Gateway);
                }

                owner.targetPosition = owner.player.transform.position;

                //目標地点の方向を向く
                //Quaternion targetRotation = Quaternion.LookRotation(owner.targetPosition - owner.transform.position);
                //owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime * owner.rotationSmooth);

                var targetRotation = Quaternion.LookRotation(owner.targetPosition - owner.transform.position).eulerAngles;
                owner.transform.localRotation = Quaternion.Slerp(owner.transform.localRotation, Quaternion.Euler(targetRotation), Time.deltaTime * owner.rotationSmooth);

                //目標に向かって進む
                owner.transform.position = Vector3.MoveTowards(owner.transform.position, owner.targetPosition, owner.speed);
            }

            public override void Exit() { }
        }

        /// <summary>
        /// ステート：逃走
        /// </summary>
        private class StateGateWay : State<Enemy>
        {
            public StateGateWay(Enemy owner) : base(owner) { }

            public override void Enter()
            {
                owner.targetPosition = owner.transform.position - (owner.player.transform.position - owner.transform.position);
            }

            public override void Excute()
            {
                if (owner.isPlayerFlg == false)
                {
                    owner.ChangeState(EnemyState.Wander);
                }

                //owner.targetPosition = -owner.player.transform.position;

                //owner.targetPosition = owner.transform.position - (owner.player.transform.position - owner.transform.position);

                //目標地点の方向を向く
                //Quaternion targetRotation = Quaternion.LookRotation(owner.targetPosition - owner.transform.position);
                //owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime * owner.rotationSmooth);

                var targetRotation = Quaternion.LookRotation(owner.targetPosition - owner.transform.position).eulerAngles;
                owner.transform.localRotation = Quaternion.Slerp(owner.transform.localRotation, Quaternion.Euler(targetRotation), Time.deltaTime * owner.rotationSmooth);

                //目標に向かって進む
                owner.transform.position = Vector3.MoveTowards(owner.transform.position, owner.targetPosition, owner.speed / 100);
            }

            public override void Exit() {
                
            }
        }
    }

    
}