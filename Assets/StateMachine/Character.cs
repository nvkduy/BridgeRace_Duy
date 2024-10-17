﻿
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{

    private IState<Character> currentState;
    [SerializeField] private Animator animator;
    [SerializeField] private ColorOS colorData;
    [SerializeField] private GameObject playerBricksPrefab;
    [SerializeField] GameObject characterVisual;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private float hightBrick;
    [SerializeField] Transform characterVisualTrans;

    protected bool isMoveup=true;
    

    public ColorType colorType { get; private set; }
    public GameObject PlayerBricksPrefab
    {
        get { return playerBricksPrefab; }
        set { playerBricksPrefab = value; }
    }
    public List<GameObject> playerBrick = new List<GameObject>();
    private string currentAnim;
    private void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    private void OnInit()
    {
        ChangeState(new IdleState());
       
    }
    public void ChangeState(IState<Character> state)
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

    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            animator.ResetTrigger(animName);
            currentAnim = animName;
            animator.SetTrigger(currentAnim);
        }
    }

    public void ChangeColor()
    {
        colorType = (ColorType)Random.Range(0, 4);
        skinnedMeshRenderer.material =  colorData.GetMaterial(colorType);

    }

    public void AddBrick(GameObject brick)
    {
        
        brick = Instantiate(playerBricksPrefab, this.transform);   
        playerBrick.Add(brick);
        //characterVisual.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + 1f);
        brick.transform.position = new Vector3(transform.position.x, transform.position.y + hightBrick, transform.position.z -0.3f);   
        //brick.transform.rotation = Quaternion.Euler(270, 0, 0);
        hightBrick += 0.08f;
        

    }

    public void RemoveBrickGround()
    {
      if (playerBrick.Count > 0)
        {
            GameObject RemoveToBrick = playerBrick[playerBrick.Count - 1];
            playerBrick.Remove(RemoveToBrick);
            Destroy(RemoveToBrick);

        }
    }


    //public void MovingUp()
    //{
    //    if (characterVisualTrans.transform.forward.z > 0 && playerBrick.Count<0)
    //    {
    //        isMoveup = false;
    //        Debug.Log(isMoveup);
    //        //Debug.Log(chacracterVisualTrans.forward.z); 
    //    }

    //}
    internal virtual void OnTriggerEnter(Collider collision)
    {
        StepStair step = collision.gameObject.GetComponent<StepStair>();
        if (step != null)
        {
           
               isMoveup = (step.colorType == colorType);
            
        }
      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Stair"))
        {
            isMoveup=true;
            Debug.Log("Out Stair");
        }
    }


}


