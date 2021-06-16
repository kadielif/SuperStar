using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : Panel
{

    public Text levelText;
    public Text moneyText;
    public RectTransform tapToStart;

    private void Start()
    {
        levelText.text = "LEVEL " + GameManager.instance.level;
        moneyText.text = DataManager.instance.money.ToString();

        tapToStart.DOScale(1.2f, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }


    public void OnPressStart()
    {
        LevelManager.instance.StartGame();
    }
}
