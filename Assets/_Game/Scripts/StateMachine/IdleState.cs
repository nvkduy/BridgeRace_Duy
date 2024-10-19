using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Character>
{
    private float currentTime;

    public void OnEnter(Character t)
    {
        t.ChangeAnim(Constant.IdleAnimName);
        currentTime = 0f;
    }

    public void OnExecute(Character t)
    {
        if (currentTime > 2f)
        {
            t.ChangeState(new FindState());

        }
        currentTime += Time.deltaTime;
    }

    public void OnExit(Character t)
    {
        t.ChangeAnim(Constant.RunAnimName);
    }

}
