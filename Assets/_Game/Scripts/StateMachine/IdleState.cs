using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Bot>
{
    private float currentTime;

    public void OnEnter(Bot t)
    {
        t.ChangeAnim(Constant.IdleAnimName);
        currentTime = 0f;
    }

    public void OnExecute(Bot t)
    {
        if (currentTime > 2f)
        {
            t.ChangeState(new FindState());

        }
        currentTime += Time.deltaTime;
    }

    public void OnExit(Bot t)
    {
        t.ChangeAnim(Constant.RunAnimName);
    }

}
