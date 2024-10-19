using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindState : IState<Character>
{
    private int brickNumber;
    private int currentBrick;
    public void OnEnter(Character t)
    {
        brickNumber = Random.Range(5,8);
        (t as Bot).BotMove(); 
    }

    public void OnExecute(Character t)
    {
        if (currentBrick < brickNumber)
        {

        }
        Debug.Log("FindState");
    }

    public void OnExit(Character t)
    {
       
    }
}
