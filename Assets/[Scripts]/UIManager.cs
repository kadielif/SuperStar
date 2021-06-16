using UnityEngine;

public class UIManager : MonoBehaviour
{
    public MainPanel mainPanel;
    public GamePanel gamePanel;
    public EndPanel endPanel;
    void Start()
    {
        mainPanel.Active(true);
        gamePanel.Active(false);
        endPanel.Active(false);

        LevelManager.instance.startEvent.AddListener(StartGame);
        LevelManager.instance.endGameEvent.AddListener(EndGame);
        
    }
    public void StartGame()
    {
        gamePanel.ActiveSmooth(true);
        mainPanel.ActiveSmooth(false);
    }
    public void EndGame(bool success)
    {

        endPanel.ActiveSmooth(true);
        gamePanel.ActiveSmooth(false);

        if (success) endPanel.Success();
        else endPanel.Fail();
    }
}
