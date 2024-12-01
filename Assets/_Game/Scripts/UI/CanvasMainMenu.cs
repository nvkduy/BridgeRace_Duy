using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainMenu : UICanvas
{
    public void PlayButton()
    {
        Close(0);
        LevelManager.Instance.LoadLevel(0);
        LevelManager.Instance.OnInit();
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        GameManager.Instance.ChangeState(GameState.GamePlay);
    }

    public void SettingsButton()
    {
        UIManager.Instance.OpenUI<CanvasSettings>().SetState(this);
    }
}