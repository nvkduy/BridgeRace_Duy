using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{

    public NavMeshAgent agent;
    [SerializeField] private GameObject botGoal;
    
    public void BotMove()
    {
        Vector3 targetBot = botGoal.transform.position;
        agent.SetDestination(targetBot);
    }

    public void FindBrick()
    {

    }
}
