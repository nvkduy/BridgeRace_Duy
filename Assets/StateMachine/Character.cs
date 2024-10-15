
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{

    private IState<Character> currentState;
    [SerializeField] private Animator animator;
    [SerializeField] private ColorOS colorData;
    [SerializeField] private GameObject bricksPrefab;
    public GameObject BricksPrefab
    {
        get { return bricksPrefab; }
        set { bricksPrefab = value; }
    }
    [SerializeField] GameObject characterVisual;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private float hightBrick;
    

    public ColorType colorType { get; private set; }

    List<GameObject> playerBrick;
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
        
        brick = Instantiate(bricksPrefab, this.transform);
        playerBrick.Add(brick);
        //characterVisual.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + 1f);
        brick.transform.position = new Vector3(transform.position.x, transform.position.y - .25f + hightBrick, transform.position.z);
        //brick.transform.rotation = Quaternion.Euler(270, 0, 0);
        ////hightBrick += 0.25f;

    }

    public void RemoveBrickGround()
    {
      
    }

}


