using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
   // [SerializeField] ColorOS color;   
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private float spacing = 0.5f;
    [SerializeField] private GroundBrick brickPrefab;

    [SerializeField] private Transform brickParent;

    public List<GroundBrick> bricks;
    private int index = 0;
    private void OnEnable()
    {
        OnInit();
    }
    private void OnInit()
    {
        bricks = new List<GroundBrick>();
        SpawnBrick();  
    }
    private void SpawnBrick()
    {
        for (int i = 0; i <= rows; i++)
        {
            for (int j = 0; j <= columns; j++)
            {
                
                GroundBrick brick = Instantiate<GroundBrick>(brickPrefab,brickParent);
                brick.transform.localPosition = new Vector3(i,0,j)*spacing;
                brick.OnInit();
                bricks.Add(brick);

            }
                
        }
    }



    private void RemoveBrick()
    {
        if (bricks.Count > 0)
        {
            GroundBrick RemoveToBrick = bricks[bricks.Count - 1];
            bricks.Remove(RemoveToBrick);
            
        }
    }

}
