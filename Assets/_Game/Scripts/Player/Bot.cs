using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{

    public NavMeshAgent agent;
    [SerializeField] private GameObject botGoal;

    int brickLayer;
    private void Awake()
    {
        
        
    }
    protected override void Start()
    {
        base.Start();
        OnInit();

    }
    private void OnInit()
    {
        brickLayer = LayerMask.GetMask("GroundBrick");

        ChangeColor();
        AddColorTypes(colorType);
    }
    public void BotMove(Vector3 position)
    {
        Vector3 targetBot = botGoal.transform.position;
        agent.SetDestination(targetBot);
    }

    public void FindBrick(float radius)
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius,brickLayer);
        foreach (var hitCollider in hitColliders)
        {
            GroundBrick brick=hitCollider.GetComponent<GroundBrick>();
            if (brick != null &&brick.colorType==colorType)
            {
                Vector3 targetBot = brick.transform.position;
            }

        }
        
    }
}
