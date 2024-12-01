using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : IState<Bot>
{
    public void OnEnter(Bot t)
    {

    }

    public void OnExecute(Bot t)
    {
        t.BotMove();
        if(t.playerBrick.Count == 0)
        {
            t.ChangeState(new FindState());
        }
    }

    public void OnExit(Bot t)
    {

    }

}
