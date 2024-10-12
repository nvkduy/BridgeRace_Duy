using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
   // [SerializeField] ColorSO color;
    [SerializeField] private Vector3 startSpawn;
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private float spacing = 0.5f;
    [SerializeField] private GameObject brickPrefab;

    private List<GameObject> bricks;
    private int index = 0;
    private void Awake()
    {
        OnInit();
    }
    private void OnInit()
    {
        bricks = new List<GameObject>();
        SpawnBrick();  
    }
    private void SpawnBrick()
    {
        for (int i = 0; i <= rows; i++)
        {
            for (int j = 0; j <= columns; j++)
            {
                
                GameObject brick = Instantiate(brickPrefab,startSpawn + new Vector3(i, 0, j) * spacing,Quaternion.identity);
                bricks.Add(brick);
            }
                
        }
    }

 

    private void RemoveBrick()
    {
        if (bricks.Count > 0)
        {
            GameObject RemoveToBrick = bricks[bricks.Count - 1];
            bricks.Remove(RemoveToBrick);
        }
    }
   
}
