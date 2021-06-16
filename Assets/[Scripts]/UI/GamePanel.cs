using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : Panel
{
    public Text moneyText;
    // Start is called before the first frame update
    void Update()
    {
        moneyText.text = DataManager.instance.money.ToString();
    }
}
