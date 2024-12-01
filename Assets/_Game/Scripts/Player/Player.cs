using DoorScript;
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
  
    private void Update()
    {
        Debug.Log(floatingJoystick.Horizontal);
        if (floatingJoystick.Horizontal != 0 && floatingJoystick.Vertical != 0)
        {


            MovePlayer();
        }
        else
        {
            ChangeAnim(Constant.IdleAnimName);
        }

    }
    internal void OnInit()
    {
        ChangeColor();

    }

    private void MovePlayer()
    {
        Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        if (direction.z < 0 || (direction.z > 0 && isMoveup))
        {
            ChangeAnim(Constant.RunAnimName);

            transform.Translate(direction * speedMove * Time.deltaTime);
            Debug.Log(isMoveup);
            Vector3 lookDirection = direction + playerVisual.transform.position;
            playerVisual.transform.LookAt(lookDirection);
        }


    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

    }
}
  




