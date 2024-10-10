using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{

    private IState<Character> currentState;
    [SerializeField] private Animator animator;
    [SerializeField] private ColorData colorData;
    [SerializeField] private GameObject bricksPrefab;
    List<GameObject> playerBrick;
    List<PlayerBrick> playerBricks;
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

    public void ChangeColor(int Index)
    {
        if (colorData != null && colorData.colorMaterials.Count > Index)
        {
            MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
            if (meshRenderer != null)
            {
                Material selectedMaterial = colorData.colorMaterials[Index];
                meshRenderer.material = selectedMaterial;
            }
        }

    }

    public void AddBrick(GameObject brick)
    {
        
        brick = Instantiate(bricksPrefab, this.transform);
        playerBrick.Add(brick);
        ////playerRender.transform.position = new Vector3(transform.position.x, transform.position.y + hightBrick, transform.position.z);
        ////brick.transform.position = new Vector3(transform.position.x, transform.position.y - .25f + hightBrick, transform.position.z);
        //brick.transform.rotation = Quaternion.Euler(270, 0, 0);
        ////hightBrick += 0.25f;
        
       
    }

}
