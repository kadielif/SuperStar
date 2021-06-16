using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = -1; 

    #region Singleton
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            GetDependencies();
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    #endregion
    
    private void GetDependencies()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || level == -1)
        {
           level = PlayerPrefs.GetInt("level",1);
        }
    }
    public void LevelUp()
    {
        DataManager.instance.SetLevel(++level);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
