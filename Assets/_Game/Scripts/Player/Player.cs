using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : Character
{
    [SerializeField] private float speedMove = 5f;
    [SerializeField] private FloatingJoystick floatingJoystick;
   

    [SerializeField] GameObject playerVisual;

    //[SerializeField] private Rigidbody rb;

    private void Start()
    {

        OnInit();
    }
    private void Update()
    { 
        
            if (floatingJoystick.Horizontal != 0 && floatingJoystick.Vertical != 0)
            {


                MovePlayer();
            }
            else
            {
                ChangeAnim(Constant.IdleAnimName);
            }
        
    }
    private void OnInit()
    {
        ChangeColor();

    }
  
    private void MovePlayer()
    {
        if (isMoveup)
        {
        ChangeAnim(Constant.RunAnimName);
        Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        transform.Translate(direction * speedMove * Time.deltaTime);
        Debug.Log(isMoveup);
        // transform.rotation = Quaternion.LookRotation(direction);
        Vector3 lookDirection = direction + playerVisual.transform.position;
        playerVisual.transform.LookAt(lookDirection);
        }


    }

    internal override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        // Kiểm tra xem đối tượng va chạm có phải là GroundBrick hay không
        GroundBrick brick = other.GetComponent<GroundBrick>();
  
        if (brick != null)
        {
            // So sánh màu của Player và màu của Brick
            if (brick.colorType == colorType)
            {
   
                Destroy(brick.gameObject);
                AddBrick(PlayerBricksPrefab);
       
            }
        }


    }

}


