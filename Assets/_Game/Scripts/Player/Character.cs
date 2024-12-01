
using DoorScript;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{

   
    [SerializeField] private Animator animator;
    [SerializeField] private ColorOS colorData;
    [SerializeField] private GroundBrick playerBricksPrefab;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private float hightBrick;

    [HideInInspector] internal Floor floor;

    protected bool isMoveup = true;
    static int randColor;
    static int oldColor;
    public ColorType ColorType { get; private set; }
    public GroundBrick PlayerBricksPrefab
    {
        get { return playerBricksPrefab; }
        set { playerBricksPrefab = value; }
    }

    public List<GroundBrick> playerBrick = new List<GroundBrick>();
    private string currentAnim;
   
    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            animator.ResetTrigger(animName);
            currentAnim = animName;
            animator.SetTrigger(currentAnim);
        }
    }

    public void ChangeColor( )
    {
          
        do
        {
            randColor = Random.Range(0, 4);
            if(randColor != oldColor)
            {
                oldColor = randColor;
                ColorType = (ColorType)randColor;
                skinnedMeshRenderer.material = colorData.GetMaterial(ColorType);
                break;
            }
            
        }
        while (true);

    }

    public void AddBrick(GroundBrick brick)
    {
        brick = Instantiate<GroundBrick>(playerBricksPrefab, this.transform);
        playerBrick.Add(brick);
        brick.ChangeColorBrick(ColorType);
        brick.transform.position = new Vector3(transform.position.x, transform.position.y + hightBrick, transform.position.z - 0.3f);
        hightBrick += 0.1f;
    }
  

    public void RemoveBrickGround()
    {
        if (playerBrick.Count > 0)
        {
            GroundBrick RemoveToBrick = playerBrick[playerBrick.Count - 1];
            playerBrick.Remove(RemoveToBrick);
            Destroy(RemoveToBrick.gameObject);
            hightBrick -= 0.1f;


        }
    }
    protected virtual void OnTriggerEnter(Collider collision)
    {
        StepStair step = Cache.GetStepStair(collision);
        if (step != null)
        {
            isMoveup = (step.ColorTypeStep == ColorType);
        }
        GroundBrick brick = Cache.GetGroundBrick(collision);
        if (brick != null)
        {
            if (brick.ColorTypeBrick == ColorType)
            {
                Destroy(brick.gameObject);
                playerBrick.Remove(brick);
                brick.OnDespawn();
                AddBrick(PlayerBricksPrefab);
                Debug.Log("Add Brick");

                // Ensure the brick is removed from the floor's bricks list
                if (brick.floor != null && brick.floor.bricks.Contains(brick))
                {
                    brick.floor.bricks.Remove(brick);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Stair"))
        {
            isMoveup = true;
            Debug.Log("Out Stair");

        }
    }

}


