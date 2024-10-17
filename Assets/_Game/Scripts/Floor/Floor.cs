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
    //
    //public List<ColorType> colors = new List<ColorType>();

    
    private int index = 0;
    
    public void OnInit()
    {
        
        SpawnBrick(brickParent);  
    }
    public void SpawnBrick(Transform brickParent)
    {
        for (int i = 0; i <= rows; i++)
        {
            for (int j = 0; j <= columns; j++)
            {
                
                GroundBrick brick = Instantiate<GroundBrick>(brickPrefab,brickParent);
                brick.transform.localPosition = new Vector3(i,0,j)*spacing;
                brick.OnInit();
                //bricks.Add(brick);

            }
                
        }
    }



    private void RemoveBrick()
    {
      
    }

}
