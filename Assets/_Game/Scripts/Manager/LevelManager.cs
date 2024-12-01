using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Bot botPrefab;
    [SerializeField] private Player player;
    [SerializeField] private float spacing;
    [SerializeField] private List<Level> levelPrefab;
    internal Action<Transform> PlayerTF;
    internal List<Bot> bots = new List<Bot>();
   

    private Level currentLevel;
    private List<Vector3> startPoints = new List<Vector3>();
    private int levelIndex;
    private int botAppearAmount;
    private Vector3 currentStartPoint;
    public int LevelIndex => levelIndex;
    public int CountOfBot => bots.Count;
    public int BotAppearAmount => botAppearAmount;
    public int CharacterAmount => currentLevel.botAmount + 1;
    public Player Player => player;
    public Vector3 FinishPoint => currentLevel.finishPoint.position;
    private void Start()
    {
        levelIndex = PlayerPrefs.GetInt("Level", 0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }

    internal void OnInit()
    {
        

        int retries = CharacterAmount;
        // Get random points for player and bots
        for (int retryCount = 0; retryCount < retries; retryCount++)
        {
            float x = 2f;
            Vector3 spawnPosition = currentStartPoint + new Vector3(x * spacing, 0, 0);
            startPoints.Add(spawnPosition);
            x += 2f;

        }
        
        SpawnBot();
    }
  
   

    private void SpawnBot()
    {
      for (int i = 0; i < currentLevel.botAmount; i++)
        {
            int ranPos = UnityEngine.Random.Range(0, startPoints.Count);
            Vector3 spawnPos = startPoints[ranPos];
            Bot Bot = Instantiate(botPrefab, spawnPos, Quaternion.identity);
            startPoints.Remove(spawnPos);
            Bot.OnInit();
            bots.Add(Bot);
      
        }
           
        
    }

 
    public void OnStartGame()
    {
        GameManager.Instance.ChangeState(GameState.GamePlay);
        foreach (var bot in bots)
        {
            bot.ChangeState(new FindState());
        }
    }

    public void OnFinshGame()
    {
        OnReset();
        Destroy(currentLevel.gameObject);
    }

    public void LoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        if (level < levelPrefab.Count)
        {
            PlayerPrefs.SetInt("Level", level);
            currentLevel = Instantiate(levelPrefab[level]);
            currentStartPoint = currentLevel.startPoint.position;
        }
    }

    public void OnReset()
    {
        RemoveAllBot();
        Destroy(player.gameObject);
       
        
    }

    internal void NextLevel()
    {
        levelIndex = (levelIndex + 1) % levelPrefab.Count;
        PlayerPrefs.SetInt("Level", levelIndex);
        OnReset();
        LoadLevel(levelIndex);
        OnInit();
        UIManager.Instance.OpenUI<CanvasGamePlay>();
    }

 

    internal void RetryLevel()
    {
        OnReset();
        LoadLevel(levelIndex);
    }

    public void RemoveAllBot()
    {
        foreach (var bot in bots)
        {
            if (bot != null)
            {
                Destroy(bot.gameObject);
            }
        }
        bots.Clear();
    }
}
