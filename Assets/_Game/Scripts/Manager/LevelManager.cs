//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LevelManager : Singleton<LevelManager>
//{
//    [SerializeField] private Bot bot;
//    [SerializeField] private Player player;
//    public List<Level> levelPrefab;
//    public Action<Transform> PlayerTF;
//    public List<Bot> bots = new List<Bot>();

//    private Level currentLevel;
//    private List<Vector3> startPoints = new List<Vector3>();
//    private int levelIndex;

//    private int botAppearAmount;
  
//    public int LevelIndex => levelIndex;
//    public int CountOfBot => bots.Count;
//    public int BotAppearAmount => botAppearAmount;
//    public int CharacterAmount => currentLevel.botAmount + 1;
//    public Player Player => player;

//    private void Start()
//    {
//        currentLevel = levelPrefab[levelIndex];
//        botAppearAmount = currentLevel.botAmount;
//        PlayerTF?.Invoke(currentLevel.startPoint);
//        a
//    }

//}
