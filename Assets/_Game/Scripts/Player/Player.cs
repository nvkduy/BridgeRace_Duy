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
        ChangeColor(1);
    }
    private void Update()
    {
        if (floatingJoystick.Horizontal != 0 && floatingJoystick.Vertical != 0)
        {
            MovePlayer();
        }
        else
        {
            ChangeAnim(Constant.RunAnimName);
        }

    }

    private void MovePlayer()
    {

        ChangeAnim("Run");
        Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        transform.Translate(direction * speedMove * Time.deltaTime);

        // transform.rotation = Quaternion.LookRotation(direction);
        Vector3 lookDirection = direction + playerVisual.transform.position;
        playerVisual.transform.LookAt(lookDirection);

    }
}

   
