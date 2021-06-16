using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public UnityEvent onPlayerCome = new UnityEvent();
    [HideInInspector] public UnityEvent startEvent = new UnityEvent();
    [HideInInspector] public EndGameEvent endGameEvent = new EndGameEvent();

    [HideInInspector] public bool LevelEnded;
    [HideInInspector] public bool LevelStart;

    [HideInInspector] public Level level;
    public GameObject player;


    #region Singleton
    public static LevelManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
    private void Start()
    {
        level = Instantiate(Resources.Load<GameObject>("levels/level-" + GameManager.instance.level)).GetComponent<Level>();
    }
    public void StartGame()
    {
        startEvent.Invoke();
        Instantiate(player, player.transform.position, player.transform.rotation);
        LevelStart = true;

        if (GameManager.instance.level < 3)
        {
            PlayerController.instance.speed = 5;
        }
        else if (GameManager.instance.level < 5)
        {
            PlayerController.instance.speed = 8;
        }
        else if (GameManager.instance.level % 5 == 0)
        {
            PlayerController.instance.speed = 13;
        }
        else if (GameManager.instance.level > 5)
        {
            PlayerController.instance.speed = 10;
        }
    }

    // call this function when user pass level as success
    public void Success()
    {
       
        endGameEvent.Invoke(true);
        GameManager.instance.LevelUp();
    }

    // call this function when user failed
    public void Fail()
    {
        endGameEvent.Invoke(false);
    }
}
public class EndGameEvent : UnityEvent<bool> { }
