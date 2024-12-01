using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindState : IState<Bot>
{
    private int brickNumber;
    
    
    public void OnEnter(Bot t)
    {
        brickNumber = Random.Range(3,6);
        t.ChangeAnim(Constant.RunAnimName);
    }

    public void OnExecute(Bot t)
    {
        if (t.playerBrick.Count < brickNumber)
        {
            t.FindBrick(t.transform.position, 10f);
            t.SetDestination(t.targetBirck);
        }
        else
        {
            t.ChangeState(new BuildState());
        }
    }

    public void OnExit(Bot t)
    {
       
    }


}
