using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] private GameObject botGoal;
    [SerializeField] private LayerMask brickLayer;
    public NavMeshAgent agent;
    public int numOfBrick;
    private IState<Bot> currentState;
    private Vector3 destionation;
    public Vector3 targetBirck;
    private Collider[] hitColliders = new Collider[15];
    public bool IsDestination => Vector3.Distance(destionation, Vector3.right * transform.position.x + Vector3.forward * transform.position.z) < 0.1f;


    protected void Start()
    {
        OnInit();

    }
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    internal void OnInit()
    {
        ChangeState(new FindState());
        ChangeColor();

    }
    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }




    public void FindBrick(Vector3 position, float radius)
    {
        numOfBrick = Physics.OverlapSphereNonAlloc(position, radius, hitColliders, brickLayer);
        float minDistance = Mathf.Infinity;
        Collider nearestEnemy = null;
        for (int i = 0; i < numOfBrick; i++)
        {
            if (hitColliders[i].gameObject != this.gameObject)
            {
                GroundBrick brick = Cache.GetGroundBrick(hitColliders[i]);
                if(brick.ColorTypeBrick == ColorType)
                {
                    float distance = Vector3.Distance(position, hitColliders[i].transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestEnemy = hitColliders[i];
                    }
                }
               
            }
        }
        if (nearestEnemy != null)
        {
            targetBirck = nearestEnemy.transform.position;
        }
        
    }

    protected override void OnTriggerEnter(Collider collision)
    {
        base.OnTriggerEnter(collision);
    }
    public void SetDestination(Vector3 position)
    {
        agent.enabled = true;
        destionation = position;
        destionation.y = 0;
        agent.SetDestination(position);
    }

}
