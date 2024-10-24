using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindState : IState<Character>
{
    

    private int brickNumber;
    private int currentBrick;
    
    
    public void OnEnter(Character t)
    {
        Bot bot = t.GetComponent<Bot>();
        brickNumber = Random.Range(5,8);
        t.ChangeAnim(Constant.RunAnimName);
        //(t as Bot).BotMove(bot.getBrick.transform.position); 
    }

    public void OnExecute(Character t)
    {
        if (currentBrick < brickNumber)
        {
            (t as Bot).FindBrick(300f);
        }
        Debug.Log("FindState");
    }

    public void OnExit(Character t)
    {
       
    }
}
