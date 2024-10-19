
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
   // [SerializeField] ColorOS color;   
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private int spawnNumber;
    [SerializeField] private float spacing = 0.5f;
    [SerializeField] private GroundBrick brickPrefab;
    [SerializeField] Character character;
    [SerializeField] private Transform brickParent;
    //
    //public List<ColorType> colors = new List<ColorType>();

   
    private int brickCount = 0;
    
    public void OnInit()
    {
        
        SpawnBrick(brickParent);  
    }
    public void SpawnBrick(Transform brickParent)
    {
        spawnNumber = rows*columns;
        int maxSpawnCount = (spawnNumber * character.colorTypes.Count) / 4;
        HashSet<Vector3> spawnedPos = new HashSet<Vector3>();
        while (brickCount < maxSpawnCount)
        {
            // Sinh ra một vị trí ngẫu nhiên trong khu vực rows x columns
            float randomX = Random.Range(0, rows + 1); // Chọn ngẫu nhiên vị trí trong khoảng từ 0 đến rows
            float randomZ = Random.Range(0, columns + 1); // Chọn ngẫu nhiên vị trí trong khoảng từ 0 đến columns

            Vector3 spawnPosition = new Vector3(randomX, 0, randomZ) * spacing;

            // Kiểm tra nếu vị trí này đã được sinh ra trước đó (tránh trùng lặp)
            
                // Thêm vị trí này vào danh sách đã sinh
                spawnedPos.Add(spawnPosition);

                // Tiến hành sinh gạch tại vị trí ngẫu nhiên
                GroundBrick brick = Instantiate<GroundBrick>(brickPrefab, brickParent);
                brick.transform.localPosition = spawnPosition;
                brick.OnInit();
                brick.floor = this;

                brickCount++;
            Debug.Log(brickCount);
            
        }
       
    }

    public void NewSpawnBrick(float time, Vector3 position)
    {
        StartCoroutine(WaitForSpawn(time, position));
    }

    IEnumerator WaitForSpawn(float time, Vector3 position)
    {
        yield return new WaitForSeconds(time);
        GroundBrick brick = Instantiate<GroundBrick>(brickPrefab, brickParent);
        brick.transform.position=position;
        brick.OnInit();
        brick.floor=this;
    }

    //private void RemoveBrick()
    //{
      
    //}

}
