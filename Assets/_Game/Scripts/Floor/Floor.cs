
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private float spacing = 1f;
    [SerializeField] private GroundBrick brickPrefab;
    [SerializeField] Character character;
    [SerializeField] private Transform brickParent;
    int amount;

    public List<GroundBrick> bricks = new List<GroundBrick>();
    private List<Vector3> spawnedPos = new List<Vector3>();

    private void Start()
    {
        
        GetPosBrick();
        amount = spawnedPos.Count / LevelManager.Instance.CharacterAmount;
        Debug.Log(brickParent);
    }
    public void InitColor(Character character)
    {


        for (int i = 0; i < amount; i++)
        {
            SpawmBrick(character.ColorType); 
        }
    }
    public void GetPosBrick()
    {
        int spawnNumber = rows * columns;
        while (spawnedPos.Count < spawnNumber)
        {
            // Sinh ra một vị trí ngẫu nhiên trong khu vực rows x columns
            float randomX = Random.Range(0, rows + 1); 
            float randomZ = Random.Range(0, columns + 1); 
            Vector3 spawnPosition = new Vector3(randomX, 0, randomZ) * spacing;
            if (!spawnedPos.Contains(spawnPosition))
            {
                spawnedPos.Add(spawnPosition);
            }
        }
    }
    private void SpawmBrick(ColorType colorType)
    {
        GroundBrick brick = Instantiate<GroundBrick>(brickPrefab, brickParent);
        int randomIndex = Random.Range(0, spawnedPos.Count);
        Vector3 randSpawn = spawnedPos[randomIndex];
        brick.transform.localPosition = randSpawn;
        spawnedPos.RemoveAt(randomIndex);
        brick.ChangeColorBrick(colorType);
        brick.floor = this;
        bricks.Add(brick);
    }

    public void NewSpawnBrick(float time, Vector3 position, ColorType colorType)
    {
        StartCoroutine(WaitForSpawn(time, position,colorType));
    }

    IEnumerator WaitForSpawn(float time, Vector3 position, ColorType colorType)
    {
        yield return new WaitForSeconds(time);
        GroundBrick newBrick = Instantiate<GroundBrick>(brickPrefab, brickParent);
       newBrick.transform.position = position;
        newBrick.ChangeColorBrick(colorType);
       newBrick.floor = this;
        bricks.Add(newBrick);

    }

    public void RemoveBricksByColor(ColorType colorType)
    {
        // Lọc các gạch có màu trùng với colorType
        for (int i = bricks.Count - 1; i >= 0; i--)
        {
            if (bricks[i] != null && bricks[i].ColorTypeBrick == colorType)
            {
                Destroy(bricks[i].gameObject); 
                bricks.RemoveAt(i);           
            }
        }
    }
    public void RemoveAllBricks()
    {
        foreach (var brick in bricks)
        {
            if (brick != null)
            {
                Destroy(brick.gameObject);
            }
        }
        bricks.Clear();
    }
}


