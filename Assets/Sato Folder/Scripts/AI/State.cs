using UnityEngine;
using System.Collections;

public class State<T>
{
    protected T owner;

    public State(T owner)
    {
        this.owner = owner;
    }

    //このステートに遷移するときに一度だけ呼ばれる
    public virtual void Enter() {}

    //このステートである間、毎フレーム呼ばれる
    public virtual void Excute() {}

    //このステートからほかのステートに遷移するときに一度だけ呼ばれる
    public virtual void Exit() {}
}
