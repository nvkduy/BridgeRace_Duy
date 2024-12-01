using TMPro;
using UnityEngine;

public class CanvasVictory : UICanvas
{
    [SerializeField] TextMeshProUGUI scoreText;

    public void SetBestScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void MainMenuButton()
    {
        Close(0);
      //  LevelManager.Instance.OnReset();
        UIManager.Instance.OpenUI<CanvasMainMenu>();
        //GameStateManager.Instance.ChangeState(GameState.mainMenu);
    }

    public void NextLevelButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        //GameStateManager.Instance.ChangeState(GameState.gamePlay);
        //LevelManager.Instance.NextLevel();
    }
}